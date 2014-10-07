using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.Windows.Controls;
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
        private StackPanel panel;
        public void init() {
            datagrid_issue = new DataGridIssue();
            infoDocument = new IssueInfoDocument(path_issues);
            datagrid_issue.ItemsSource = infoDocument.InfoIssues();
            datagrid_issue.CurrentCellChanged += handleCurrentCellChanged;
            panel = new StackPanel();
            panel.Orientation = Orientation.Vertical;
            this.Reload();
        }



        public void Reload() {
            this.panel.Children.Clear();
            foreach (IssueInfo info in infoDocument.InfoIssues()) {
                var panel = new IssueInfoPanel(info);
                panel.IssueEditBegin += this.handleIssueEditBegin;
                this.panel.Children.Add(panel);
            }
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
        private void handleIssueEditBegin(object sender, IssueEditEventArgs e) {
            var info = e.Info;
            var editPanel = new IssueEditPage(info);
            if (editPanel.ShowDialog() == true) {
                var commands = editPanel.Commands;
                foreach (var command in commands)
                {
                    command.Do();
                }
                if (commands.Count > 0) {
                    doSave();
                    this.Reload();
                }
            }
        }
        public StackPanel Panel{
            get { return panel; }
        }
    }
}
