using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;

namespace LifeTicker
{
    class IssueManager
    {
        public static String DATA_DIR = "D:/weiyun/notes/lifeticker/";
        private static String path_issues = DATA_DIR + "issues.xml";
        private static LinkedList<IssueInfo> issue_infos;
        private static XmlDocument xml_doc;
        private static XmlElement root_element;


        //return all Issues with information
        public static LinkedList<IssueInfo> getIssueInfos()
        {
            XmlDocument dom = new XmlDocument();
            dom.Load(path_issues);
            LinkedList<IssueInfo> rlt = new LinkedList<IssueInfo>();
            XmlElement root = dom.DocumentElement;
            XmlNodeList list = root.GetElementsByTagName("Issue");
            System.Collections.IEnumerator itr = list.GetEnumerator();
            while (itr.MoveNext())
            {
                rlt.AddLast(new IssueInfo((XmlNode)itr.Current));
            }
            xml_doc = dom;
            root_element = root;
            issue_infos = rlt;
            return rlt;
        }
        public static void doSave(){
            xml_doc.Save(path_issues);
        }
        public static void addIssue(IssueInfo info) {
            issue_infos.AddLast(info);
            root_element.AppendChild(info.toXmlElementWithXmlDocument(xml_doc));
            doSave();
        }
    }
}
