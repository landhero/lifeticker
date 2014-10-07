using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using com.zhanghs.lifeticker.controller;
using com.zhanghs.lifeticker.view;

namespace com.zhanghs.lifeticker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.loadIssues();
        }

        //load issues into the main panel
        public void loadIssues()
        {
            outmost_panel.Children.Clear();

            WrapPanel panel_issues = new WrapPanel();
            panel_issues.Orientation = Orientation.Vertical;
            IssueManager im = new IssueManager();
            im.init();
            //panel_issues.Children.Add(im.getDataGridIssue());
            outmost_panel.Children.Add(im.Panel);
        }

    }
}
