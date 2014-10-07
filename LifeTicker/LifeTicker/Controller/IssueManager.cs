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
        private IssueInfoDocument infoDocument;
        private  DataGridIssue datagrid_issue;
        public void init() {
            datagrid_issue = new DataGridIssue();
            infoDocument = new IssueInfoDocument(path_issues);
            datagrid_issue.ItemsSource = infoDocument.InfoIssues();
            datagrid_issue.CurrentCellChanged += handleCurrentCellChanged;
        }

        public List<IssueInfoPanel> InfoPanels() {
            List<IssueInfoPanel> rlt = new List<IssueInfoPanel>();
            foreach (IssueInfo info in infoDocument.InfoIssues()) {
                rlt.Add(new IssueInfoPanel(info));
            }
            return rlt;
        }

        public DataGridIssue getDataGridIssue() {
            return datagrid_issue;
        }

        private void doSave(){
            infoDocument.Save();
        }
        private void handleCurrentCellChanged(object sender, EventArgs e) {
            doSave();
        }
    }
}
