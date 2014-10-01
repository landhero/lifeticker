using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTicker
{
    public class IssueInfo
    {
        public string Title { get; set; }
        public IssueStatus Status { get; set; }
    }
    [Flags] public enum IssueStatus {Ready, Doing, Blocked, Finished}
}
