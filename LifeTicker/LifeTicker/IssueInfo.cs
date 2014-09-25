using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTicker
{
    class IssueInfo
    {
        public string Title { get; set; }
        public IssueStatus Status { get; set; }
    }
    enum IssueStatus {Ready, Doing, Blocked, Finished}
}
