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

namespace LifeTicker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataGrid grid_issues;
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
            Button button_add_issue = new Button();
            button_add_issue.Content = "Add an issue";
            button_add_issue.Click += this.handle_add_issue;
            panel_issues.Children.Add(button_add_issue);
            outmost_panel.Children.Add(panel_issues);

            grid_issues = new DataGrid();   // data grid for issues
            grid_issues.AutoGenerateColumns = false;
            DataGridTextColumn col_title = new DataGridTextColumn();   // Title Column
            col_title.Header = "Title";
            col_title.Binding = new Binding("Title");
            grid_issues.Columns.Add(col_title);
            DataGridComboBoxColumn col_status = new DataGridComboBoxColumn();
            col_status.Header = "Status";
            col_status.ItemsSource = Enum.GetValues(typeof(IssueStatus)).Cast<IssueStatus>();
            col_status.SelectedItemBinding = new Binding("Status");
            grid_issues.Columns.Add(col_status);
            grid_issues.ItemsSource = IssueManager.getIssueInfos(); // Set the source and show it
            grid_issues.CurrentCellChanged += this.handleCellEditEnding;
            Grid.SetRow(grid_issues, 0);
            Grid.SetColumn(grid_issues, 0); 
            outmost_panel.Children.Add(grid_issues);
        }

        public void handle_add_issue(object sender, RoutedEventArgs e) {
            IssueInfo info = add_issue();
            if (info != null) {
                IssueManager.addIssue(info);
                grid_issues.ItemsSource = IssueManager.getIssueInfos();
            }
        }

        public IssueInfo add_issue() {
            AddIssueDialog dialog = new AddIssueDialog();
            if (dialog.ShowDialog() == true) {
                return dialog.getIssueInfo();
            }
            return null;
        }
        private void handleCellEditEnding(object sender,  EventArgs e){
            IssueManager.doSave();
        }

    }

    /**
     * A pop-up dialog for adding issue
     */
    public class AddIssueDialog : Window {
        private TextBox text_title;
        private IssueInfo info;
        public AddIssueDialog() {
            this.Title = "Add an Issue";
            this.Width = 400;
            this.Height = 400;
            WrapPanel panel = new WrapPanel();
            panel.Orientation = Orientation.Vertical;
            text_title = new TextBox();
            panel.Children.Add(text_title);
            Button button = new Button();
            button.Content = "OK";
            button.Click += this.handle_okey_clicked;
            panel.Children.Add(button);
            this.AddChild(panel);
            info = new IssueInfo();
        }
        private void handle_okey_clicked(object sender, RoutedEventArgs e) {
            info.Title = text_title.Text;
            info.Status = IssueStatus.Ready;
            this.DialogResult = true;
        }
        public IssueInfo getIssueInfo(){
            if (info != null && info.Title != null && !info.Title.Equals(""))
                return info;
            return null;
        }
    }
}
