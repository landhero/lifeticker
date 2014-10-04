using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using com.zhanghs.lifeticker.model;

namespace com.zhanghs.lifeticker.view
{
    /**
     * DataGridIssue: DataGrid to show a list of issues
     */
    class DataGridIssue:DataGrid
    {
        public DataGridIssue() : base(){
            AutoGenerateColumns = false;
            DataGridTextColumn col_title = new DataGridTextColumn();   // Title Column
            col_title.Header = "Title";
            col_title.Binding = new Binding("Title");
            Columns.Add(col_title);
            DataGridComboBoxColumn col_status = new DataGridComboBoxColumn(); //Status Column
            col_status.Header = "Status";
            col_status.ItemsSource = Enum.GetValues(typeof(IssueStatus)).Cast<IssueStatus>();
            col_status.SelectedItemBinding = new Binding("Status");
            Columns.Add(col_status);
        }
    }
}
