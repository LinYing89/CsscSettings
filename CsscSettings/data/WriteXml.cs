using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CsscSettings.data
{
    public class WriteXml
    {
        public static string CONFIG_FILE = Application.StartupPath + "\\config.xml";

        XmlDocument doc;
        XmlElement root;

        public static string nodeUser = "user";
        public static string nodeName = "name";
        public static string nodePsd = "psd";

        public static string nodeVpnSer = "vpnSer";
        public static string nodeIp = "ip";
        public static string nodePort = "port";

        public static string nodeYiDong = "yiDong";
        public static string nodeLianTong = "lianTong";
        public static string nodeDianXin = "dianXin";
        public static string nodeJiaoHuanJi = "jiaoHuanJi";

        public static string attrEth = "eth";

        public static string nodeLocalSers = "localSers";
        public static string nodeLocalSer = "localSer";
        public static string nodeProtocolType = "protocolType";

        public void Write()
        {
            doc = new XmlDocument();
            XmlDeclaration xmlDec = doc.CreateXmlDeclaration("1.0", "", "yes");
            doc.PrependChild(xmlDec);
            root = doc.CreateElement("config");//主内容
            doc.AppendChild(root);

            XmlElement xmlUser = doc.CreateElement(nodeUser);
            XmlAttribute attrUserName = doc.CreateAttribute(nodeName);
            attrUserName.Value = Config.Ins.User.Name;
            xmlUser.Attributes.Append(attrUserName);
            XmlAttribute attrUserPsd = doc.CreateAttribute(nodePsd);
            attrUserPsd.Value = Config.Ins.User.Psd;
            xmlUser.Attributes.Append(attrUserPsd);
            root.AppendChild(xmlUser);

            XmlElement xmlVpnSer = doc.CreateElement(nodeVpnSer);
            XmlAttribute attrVpnSerIp = doc.CreateAttribute(nodeIp);
            attrVpnSerIp.Value = Config.Ins.VpnSer.Ip;
            xmlVpnSer.Attributes.Append(attrVpnSerIp);
            XmlAttribute attrVpnSerPort = doc.CreateAttribute(nodePort);
            attrVpnSerPort.Value = Config.Ins.VpnSer.Port.ToString();
            xmlVpnSer.Attributes.Append(attrVpnSerPort);
            root.AppendChild(xmlVpnSer);

            //移动
            XmlElement xmlYiDong = doc.CreateElement(nodeYiDong);
            XmlAttribute attrYiDongIp = doc.CreateAttribute(nodeIp);
            attrYiDongIp.Value = Config.Ins.WkYiDong.Ip;
            xmlYiDong.Attributes.Append(attrYiDongIp);
            XmlAttribute attrYiDongEth = doc.CreateAttribute(attrEth);
            attrYiDongEth.Value = Config.Ins.WkYiDong.Eth;
            xmlYiDong.Attributes.Append(attrYiDongEth);
            root.AppendChild(xmlYiDong);

            //联通
            XmlElement xmlLianTong = doc.CreateElement(nodeLianTong);
            XmlAttribute attrLianTongIp = doc.CreateAttribute(nodeIp);
            attrLianTongIp.Value = Config.Ins.WkLianTong.Ip;
            xmlLianTong.Attributes.Append(attrLianTongIp);
            XmlAttribute attrLianTongEth = doc.CreateAttribute(attrEth);
            attrLianTongEth.Value = Config.Ins.WkLianTong.Eth;
            xmlLianTong.Attributes.Append(attrLianTongEth);
            root.AppendChild(xmlLianTong);

            //电信
            XmlElement xmlDianXin = doc.CreateElement(nodeDianXin);
            XmlAttribute attrDianXinIp = doc.CreateAttribute(nodeIp);
            attrDianXinIp.Value = Config.Ins.WkDianXin.Ip;
            xmlDianXin.Attributes.Append(attrDianXinIp);
            XmlAttribute attrDianXinEth = doc.CreateAttribute(attrEth);
            attrDianXinEth.Value = Config.Ins.WkDianXin.Eth;
            xmlDianXin.Attributes.Append(attrDianXinEth);
            root.AppendChild(xmlDianXin);

            //交换机
            XmlElement xmlJiaoHuanJi = doc.CreateElement(nodeJiaoHuanJi);
            XmlAttribute attrJiaoHuanJiIp = doc.CreateAttribute(nodeIp);
            attrJiaoHuanJiIp.Value = Config.Ins.WkJiaoHuanJi.Ip;
            xmlJiaoHuanJi.Attributes.Append(attrJiaoHuanJiIp);
            XmlAttribute attrJiaoHuanJiEth = doc.CreateAttribute(attrEth);
            attrJiaoHuanJiEth.Value = Config.Ins.WkJiaoHuanJi.Eth;
            xmlJiaoHuanJi.Attributes.Append(attrJiaoHuanJiEth);
            root.AppendChild(xmlJiaoHuanJi);

            XmlElement xmlLocalSers = doc.CreateElement(nodeLocalSers);
            foreach(LocalSer ls in Config.Ins.ListLocalSer){
                XmlElement xmlLocalSer = doc.CreateElement(nodeLocalSer);

                XmlAttribute attrName = doc.CreateAttribute(nodeName);
                attrName.Value = ls.Name;
                xmlLocalSer.Attributes.Append(attrName);

                XmlAttribute attrIp = doc.CreateAttribute(nodeIp);
                attrIp.Value = ls.Ip;
                xmlLocalSer.Attributes.Append(attrIp);

                XmlAttribute attrPort = doc.CreateAttribute(nodePort);
                attrPort.Value = ls.Port.ToString();
                xmlLocalSer.Attributes.Append(attrPort);

                XmlAttribute attrProtocolType = doc.CreateAttribute(nodeProtocolType);
                attrProtocolType.Value = ls.ProtocolType;
                xmlLocalSer.Attributes.Append(attrProtocolType);
                xmlLocalSers.AppendChild(xmlLocalSer);

            }
            root.AppendChild(xmlLocalSers);

            doc.Save(CONFIG_FILE);
        }


    }
}
