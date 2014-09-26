using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;

namespace LifeTicker
{
    class DataHelper
    {
        public static String DATA_DIR = "D:/weiyun/notes/lifeticker/";
        //return all Issues
        public static LinkedList<IssueInfo> getIssueInfos() {
            String path_issues = DATA_DIR + "issues.xml"; //fetch the file
            XmlDocument dom = new XmlDocument();
            dom.Load(path_issues);
            LinkedList<IssueInfo> rlt = new LinkedList<IssueInfo>();
            XmlElement root = dom.DocumentElement;
            XmlNodeList list = root.GetElementsByTagName("Issue");
            Console.WriteLine(list[0].InnerXml);
            System.Collections.IEnumerator itr = list.GetEnumerator();
            while (itr.MoveNext()) {
                rlt.AddLast(loadFromXML((XmlNode)itr.Current));
            }
            return rlt;
        }

        //convert a xml node to IssueInfo object
        public static IssueInfo loadFromXML(XmlNode node) {
            IssueInfo rlt = new IssueInfo();
            rlt.Title = node.SelectSingleNode("Title").InnerText;
            rlt.Status = (IssueStatus) Enum.Parse( typeof(IssueStatus), node.SelectSingleNode("Status").InnerText);
            return rlt;
        }
    }
}
