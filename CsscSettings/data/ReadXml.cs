using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CsscSettings.data
{
    public class ReadXml
    {
        private XmlDocument document;
        private XmlNode rootElement;

        public void readConfig()
        {
            try
            {
                document = new XmlDocument();
                document.Load(WriteXml.CONFIG_FILE);
                rootElement = document.SelectSingleNode("config");
            }
            catch
            {
                return;
            }

            XmlNode xmlUser = rootElement.SelectSingleNode(WriteXml.nodeUser);
            if (null != xmlUser)
            {
                XmlAttributeCollection attrUser = xmlUser.Attributes;
                foreach (XmlAttribute attr in attrUser)
                {
                    if (attr.Name.Equals(WriteXml.nodeName))
                    {
                        Config.Ins.User.Name = attr.Value;
                    }
                    else if (attr.Name.Equals(WriteXml.nodePsd))
                    {
                        Config.Ins.User.Psd = attr.Value;
                    }
                }
            }

            XmlNode xmlVpnSer = rootElement.SelectSingleNode(WriteXml.nodeVpnSer);
            if (null != xmlVpnSer)
            {
                XmlAttributeCollection attrVpnSer = xmlVpnSer.Attributes;
                foreach (XmlAttribute attr in attrVpnSer)
                {
                    if (attr.Name.Equals(WriteXml.nodeIp))
                    {
                        Config.Ins.VpnSer.Ip = attr.Value;
                    }
                    else if (attr.Name.Equals(WriteXml.nodePort))
                    {
                        Config.Ins.VpnSer.Port = Convert.ToInt32(attr.Value);
                    }
                }
            }

            XmlNode xmlYiDong = rootElement.SelectSingleNode(WriteXml.nodeYiDong);
            if (null != xmlYiDong)
            {
                XmlAttributeCollection attrYiDong = xmlYiDong.Attributes;
                foreach (XmlAttribute attr in attrYiDong)
                {
                    if (attr.Name.Equals(WriteXml.nodeIp))
                    {
                        Config.Ins.WkYiDong.Ip = attr.Value;
                    }
                    else if (attr.Name.Equals(WriteXml.attrEth))
                    {
                        Config.Ins.WkYiDong.Eth = attr.Value;
                    }
                }
            }

            XmlNode xmlLianTong = rootElement.SelectSingleNode(WriteXml.nodeLianTong);
            if (null != xmlLianTong)
            {
                XmlAttributeCollection attrLianTong = xmlLianTong.Attributes;
                foreach (XmlAttribute attr in attrLianTong)
                {
                    if (attr.Name.Equals(WriteXml.nodeIp))
                    {
                        Config.Ins.WkLianTong.Ip = attr.Value;
                    }
                    else if (attr.Name.Equals(WriteXml.attrEth))
                    {
                        Config.Ins.WkLianTong.Eth = attr.Value;
                    }
                }
            }

            XmlNode xmlDianXin = rootElement.SelectSingleNode(WriteXml.nodeDianXin);
            if (null != xmlDianXin)
            {
                XmlAttributeCollection attrDianXin = xmlDianXin.Attributes;
                foreach (XmlAttribute attr in attrDianXin)
                {
                    if (attr.Name.Equals(WriteXml.nodeIp))
                    {
                        Config.Ins.WkDianXin.Ip = attr.Value;
                    }
                    else if (attr.Name.Equals(WriteXml.attrEth))
                    {
                        Config.Ins.WkDianXin.Eth = attr.Value;
                    }
                }
            }

            XmlNode xmlJiaoHuanJi = rootElement.SelectSingleNode(WriteXml.nodeJiaoHuanJi);
            if (null != xmlJiaoHuanJi)
            {
                XmlAttributeCollection attrJiaoHuanJi = xmlJiaoHuanJi.Attributes;
                foreach (XmlAttribute attr in attrJiaoHuanJi)
                {
                    if (attr.Name.Equals(WriteXml.nodeIp))
                    {
                        Config.Ins.WkJiaoHuanJi.Ip = attr.Value;
                    }
                    else if (attr.Name.Equals(WriteXml.attrEth))
                    {
                        Config.Ins.WkJiaoHuanJi.Eth = attr.Value;
                    }
                }
            }

            XmlNode xmlLocalSers = rootElement.SelectSingleNode(WriteXml.nodeLocalSers);
            if (null != xmlLocalSers)
            {
                XmlNodeList xmlLocalSer = xmlLocalSers.SelectNodes(WriteXml.nodeLocalSer);

                foreach (XmlNode xmlls in xmlLocalSer)
                {
                    LocalSer ls = new LocalSer();
                    XmlAttributeCollection attrLocalSer = xmlls.Attributes;
                    foreach (XmlAttribute attr in attrLocalSer)
                    {
                        if(attr.Name.Equals(WriteXml.nodeName)){
                            ls.Name = attr.Value;
                        }
                        else if (attr.Name.Equals(WriteXml.nodeIp))
                        {
                            ls.Ip = attr.Value;
                        }
                        else if (attr.Name.Equals(WriteXml.nodePort))
                        {
                            ls.Port = Convert.ToInt16(attr.Value);
                        }
                        else if (attr.Name.Equals(WriteXml.nodeProtocolType))
                        {
                            ls.ProtocolType = attr.Value;
                        }
                    }
                    foreach (LocalSer l in Config.Ins.ListLocalSer)
                    {
                        if (l.Name.Equals(ls.Name))
                        {
                            l.Ip = ls.Ip;
                            l.Port = ls.Port;
                            l.ProtocolType = ls.ProtocolType;
                        }
                    }
                }
            }
        }
    }
}
