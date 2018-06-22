using CsscSettings.data;
using CsscSettings.forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading;

namespace CsscSettings.net
{
    public class MyClient
    {
        public event EventHandler EventConnectOk;
        public event EventHandler EventConnectFail;
        public event EventHandler EventConnectBreak;
        public event EventHandler EventReceivedNetState;
        public event EventHandler EventReceivedOk;
        public event EventHandler EventReceivedError;

        private TcpClient client;
        private byte[] recBuffer;

        public MyClient()
        {
            recBuffer = new byte[1024];
        }

        public void link()
        {
            try
            {
                if (null == client)
                {
                    client = new TcpClient();
                    //client.SendTimeout = 5000;
                }
                if (!client.Connected)
                {
                    client.BeginConnect(Config.Ins.VpnSer.Ip, Config.Ins.VpnSer.Port, Connected, client);

                }
            }
            catch (Exception)
            {
                if (null != EventConnectFail)
                {
                    EventConnectFail(null, null);
                }
            }
        }

        public bool isConnect()
        {
            if (null == client || !client.Connected)
            {
                return false;
            }
            return true;
        }

        private void Connected(IAsyncResult iar)
        {
            try
            {
                client = (TcpClient)iar.AsyncState;
                client.Client.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
                client.EndConnect(iar);
                client.SendTimeout = 10;
                if ((client != null) && (client.Connected))
                {
                    NetworkStream stream = client.GetStream();
                    if (stream.CanRead)
                    {
                        stream.BeginRead(recBuffer, 0, recBuffer.Length, new AsyncCallback(AsyncReadCallBack), client);
                    }
                    if (null != EventConnectOk)
                    {
                        EventConnectOk(null, null);
                    }
                }
            }
            catch (Exception)
            {
                if (null != EventConnectFail)
                {
                    EventConnectFail(null, null);
                }
            }
        }

        private void AsyncReadCallBack(IAsyncResult iar)
        {
            try
            {
                client = (TcpClient)iar.AsyncState;
                if ((client == null) || (!client.Connected)) return;
                int NumOfBytesRead;
                NetworkStream ns = client.GetStream();
                NumOfBytesRead = ns.EndRead(iar);
                if (NumOfBytesRead > 0)
                {
                    byte[] buffer = new byte[NumOfBytesRead];
                    Array.Copy(recBuffer, 0, buffer, 0, NumOfBytesRead);
                    analysis(buffer);
                    ns.BeginRead(recBuffer, 0, recBuffer.Length, new AsyncCallback(AsyncReadCallBack), client);
                }
                else
                {
                    myClose();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void send(string str)
        {
            send(System.Text.Encoding.ASCII.GetBytes(str));
        }

        public void send(byte[] by)
        {
            if (null == client || !client.Connected)
            {
                if (null != EventConnectBreak)
                {
                    EventConnectBreak(null, null);
                }
                return;
            }
            try
            {
                //NetworkStream ns = client.GetStream();
                client.GetStream().WriteTimeout = 10;
                client.GetStream().Write(by, 0, by.Length);
                //ns.BeginWrite(by, 0, by.Length, null, null);
                //Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
                //EventUserError(null, null);
            }
        }

        public void send(List<string> listStr)
        {
            //listOrder = listStr;
            ThreadPool.QueueUserWorkItem(sendList, listStr);
            //Thread th = new Thread(sendList);
            //th.Start();
        }

        private void sendList(object list)
        {
            List<string> listO = (List<string>)list;
            foreach (string str in listO)
            {
                send(str);
                Thread.Sleep(200);
            }
        }

        public void myClose()
        {
            if (null != client)
            {
                if (client.Connected)
                {
                    client.GetStream().Close();
                    client.Close();
                }
                client = null;
            }
        }

        public void analysis(byte[] bys)
        {
            string strMsg = System.Text.Encoding.ASCII.GetString(bys);
            //strMsg = System.Text.RegularExpressions.Regex.Replace(strMsg, @"\b\s+\b", " ");
            strMsg = strMsg.Replace("\r", "");
            string[] msgs = strMsg.Split(new char[] { '\n' });
            Debug.WriteLine("analysis:" + strMsg, "MyClient");
            foreach (string msg in msgs)
            {
                string str = msg;
                if (string.IsNullOrWhiteSpace(str))
                {
                    continue;
                }
                if (str.Contains("ok"))
                {
                    if (null != EventReceivedOk)
                    {
                        EventReceivedOk(null, null);
                    }
                }
                else if (str.Contains("error"))
                {
                    EventReceivedError?.Invoke(null, null);
                }
                else if (str.StartsWith("status"))
                {
                    str = str.Substring(str.IndexOf(" ") + 1);
                    string[] channels = str.Split(new char[] { ' ' });
                    if (channels.Length >= 4)
                    {
                        try
                        {
                            bool haved = false;
                            foreach (ChannelState cs in FrmNetState.listChannel)
                            {
                                if (cs.Name.Equals(channels[0]))
                                {
                                    haved = true;
                                    setChannedlState(cs, channels);
                                    break;
                                }
                            }
                            if (!haved)
                            {
                                ChannelState cs = new ChannelState();
                                cs.Name = channels[0];
                                setChannedlState(cs, channels);
                                FrmNetState.listChannel.Add(cs);
                            }
                            if (null != EventReceivedNetState)
                            {
                                EventReceivedNetState(null, null);
                            }
                        }
                        catch (Exception) { }
                    }
                }
            }
            //EventReceivedNetState(null, null);
        }

        private void setChannedlState(ChannelState cs, string[] channels)
        {
            cs.ChannelMain.Name = channels[2];
            cs.ChannelMain.Strength = Convert.ToInt16(channels[3]);
            if (channels.Length >= 6)
            {
                cs.ChannelReserve1.Name = channels[4];
                cs.ChannelReserve1.Strength = Convert.ToInt16(channels[5]);
            }
            if (channels.Length >= 8)
            {
                cs.ChannelReserve2.Name = channels[6];
                cs.ChannelReserve2.Strength = Convert.ToInt16(channels[7]);
            }
        }
    }
}
