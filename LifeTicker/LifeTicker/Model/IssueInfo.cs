using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace com.zhanghs.lifeticker.model
{
    public class IssueInfo
    {
        public IssueInfo() {
            _id = IssueInfo.getCurrentID();
        }

        public IssueInfo(XmlNode node) {
            _id = node.SelectSingleNode("ID").InnerText;
            Title = node.SelectSingleNode("Title").InnerText;
            Status = (IssueStatus) Enum.Parse( typeof(IssueStatus), node.SelectSingleNode("Status").InnerText);
        }

        public  XmlElement toXmlElementWithXmlDocument(XmlDocument doc){
            XmlElement node = doc.CreateElement("Issue");
            XmlElement node_id = doc.CreateElement("ID");
            node_id.InnerText = _id;
            node.AppendChild(node_id);
            XmlElement node_title = doc.CreateElement("Title");
            node_title.InnerText = Title;
            node.AppendChild(node_title);
            XmlElement node_status = doc.CreateElement("Status");
            node_status.InnerText = Enum.GetName(typeof(IssueStatus), Status);
            node.AppendChild(node_status);
            return node;
        }

        public string Title { get; set; }
        public IssueStatus Status { get; set; }
        
        private string _id;
        private static string getCurrentID()
        {
            return System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
    }
    [Flags] public enum IssueStatus {Ready, Doing, Blocked, Finished}
}
