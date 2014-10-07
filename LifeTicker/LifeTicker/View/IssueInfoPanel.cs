using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using com.zhanghs.lifeticker.model;
using System.Windows.Documents;
using System.Windows;

namespace com.zhanghs.lifeticker.view
{
    class IssueInfoPanel : WrapPanel
    {
        private IssueInfo info;
        private CheckBox checkBox;
        private Label label;
        private Button button;
        private Hyperlink hyperLink;
        public IssueInfoPanel(IssueInfo info) {
            this.info = info;
            InitComponents();
        }
 
        private void InitComponents (){
            this.Orientation = Orientation.Horizontal;
            checkBox = new CheckBox();
            checkBox.Margin = new Thickness(0,1,5,0);
            Children.Add(checkBox);
            Hyperlink hyperlink = new Hyperlink(new Run(info.Title));
            TextBlock textBlock1 = new TextBlock();
            textBlock1.Inlines.Clear();
            textBlock1.Inlines.Add(new Run("[" + info.Status.ToString() + "] "));
            textBlock1.Inlines.Add(hyperlink);
            Children.Add(textBlock1);
            hyperlink.Click += this.handleClicked;
        }

        public bool IsChecked()
        {
            return checkBox.IsChecked.GetValueOrDefault(false);
        }
        public void handleClicked(object sender, EventArgs e) {
            Console.Write("test");
        }
    }
    
}
