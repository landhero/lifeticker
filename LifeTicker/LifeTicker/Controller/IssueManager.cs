using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using com.zhanghs.lifeticker.model;
using com.zhanghs.lifeticker.view;

namespace com.zhanghs.lifeticker.controller
{
    class IssueManager
    {
        public static String DATA_DIR = "D:/weiyun/notes/lifeticker/";
        private static String path_issues = DATA_DIR + "issues.xml";
        private  List<IssueInfo> issue_infos;
        private  XmlDocument xml_doc;
        private  XmlElement root_element;
        private  DataGridIssue datagrid_issue;
        public void init() {
            datagrid_issue = new DataGridIssue();
            getIssueInfos();
            datagrid_issue.ItemsSource = issue_infos;
            datagrid_issue.CurrentCellChanged += handleCurrentCellChanged;
        }

        public DataGridIssue getDataGridIssue() {
            return datagrid_issue;
        }

        //return all Issues with information
        private List<IssueInfo> getIssueInfos()
        {
            XmlDocument dom = new XmlDocument();
            dom.Load(path_issues);
            List<IssueInfo> rlt = new List<IssueInfo>();
            XmlElement root = dom.DocumentElement;
            XmlNodeList list = root.GetElementsByTagName("Issue");
            System.Collections.IEnumerator itr = list.GetEnumerator();
            while (itr.MoveNext())
            {
                rlt.Add(new IssueInfo((XmlNode)itr.Current));
            }
            xml_doc = dom;
            root_element = root;
            issue_infos = rlt;
            return rlt;
        }
        private void doSave(){
            root_element.IsEmpty = true;
            foreach(IssueInfo info in issue_infos)
            {
                root_element.AppendChild(info.toXmlElementWithXmlDocument(xml_doc));
            }
            xml_doc.Save(path_issues);
        }
        private void handleCurrentCellChanged(object sender, EventArgs e) {
            doSave();
        }
    }
}
