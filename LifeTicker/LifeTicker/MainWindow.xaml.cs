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
        public MainWindow()
        {
            InitializeComponent();
            this.loadIssues();
        }
        
        //load issues into the main panel
        public void loadIssues()
        {
            outmost_grid.Children.Clear();
            DataGrid grid_issues = new DataGrid();
            grid_issues.AutoGenerateColumns = false;

            DataGridTextColumn col_title = new DataGridTextColumn();   // Title Column
            col_title.Header = "Title";
            col_title.Binding = new Binding("Title");
            grid_issues.Columns.Add(col_title);

            DataGridTextColumn col_status = new DataGridTextColumn();   // Status Column
            col_status.Header = "Status";
            col_status.Binding = new Binding("Status");
            grid_issues.Columns.Add(col_status);

            grid_issues.ItemsSource = DataHelper.getIssueInfos(); // Set the source and show it
            Grid.SetRow(grid_issues, 0);
            Grid.SetColumn(grid_issues, 0); 
            outmost_grid.Children.Add(grid_issues);
        }

    }
}
