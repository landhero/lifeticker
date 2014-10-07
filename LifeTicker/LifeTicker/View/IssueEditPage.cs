using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using com.zhanghs.lifeticker.model;
using System.Windows;
using com.zhanghs.lifeticker.controller.commands;

namespace com.zhanghs.lifeticker.view
{
    class IssueEditPage:Window
    {
        private IssueInfo info;
        private TextBox textTitle;
        private StackPanel panel;
        private List<AbstractCommand> commands;
        public IssueEditPage(IssueInfo info=null) {
            if (info == null)
                this.info = new IssueInfo();
            else this.info = info;
            commands = new List<AbstractCommand>();
            this.InitComponents();
        }

        private void InitComponents() {
            panel = new StackPanel();
            panel.Orientation = Orientation.Vertical;
            textTitle = new TextBox();
            textTitle.Text = info.Title;
            panel.Children.Add(textTitle);

            var button = new Button();
            button.Content = "Save";
            button.Click += handleSaveClicked;
            panel.Children.Add(button);
            this.AddChild(panel);
            
        }

        public List<AbstractCommand> Commands {
            get { return commands; }
        }

        private void handleSaveClicked(object sender, RoutedEventArgs e)
        {
            commands.Clear();
            if (!textTitle.Text.Equals(info.Title)) {
                commands.Add(new IssueTitleChangedCommand(info, textTitle.Text));
            }
            this.DialogResult = true;
        }
    }
}
