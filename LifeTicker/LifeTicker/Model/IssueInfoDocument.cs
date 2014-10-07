using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace com.zhanghs.lifeticker.model
{
    class IssueInfoDocument
    {
        // The path of Xml file 
        public string Path{ get; set;}
        
        public IssueInfoDocument(string path) {
            Path = path;
            this.LoadIssues();
        }

        // Load the issues;
        private void LoadIssues(){
            xmlDoc = new XmlDocument();
            xmlDoc.Load(Path);
            infoIssues = new List<IssueInfo>();
            rootElement = xmlDoc.DocumentElement;
            XmlNodeList list = rootElement.GetElementsByTagName("Issue");
            System.Collections.IEnumerator itr = list.GetEnumerator();
            while (itr.MoveNext())
            {
                infoIssues.Add(new IssueInfo((XmlNode)itr.Current));
            }
        }


        public List<IssueInfo> InfoIssues(){
            return infoIssues;
        }

        public void Save()
        {
            rootElement.IsEmpty = true;
            foreach (IssueInfo info in infoIssues)
            {
                rootElement.AppendChild(info.toXmlElementWithXmlDocument(xmlDoc));
            }
            xmlDoc.Save(Path);
        }

        private XmlDocument xmlDoc;
        private XmlElement rootElement;
        private List<IssueInfo> infoIssues;
    }

}
