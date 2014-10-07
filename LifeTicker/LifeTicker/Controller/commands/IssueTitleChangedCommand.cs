using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.zhanghs.lifeticker.model;

namespace com.zhanghs.lifeticker.controller.commands
{
    class IssueTitleChangedCommand : AbstractCommand
    {
        private string oldTitle;
        private string newTitle;
        private IssueInfo info;

        public IssueTitleChangedCommand(IssueInfo info, string title) {
            this.info = info;
            newTitle = title;
        }

        public override void Do()
        {
            oldTitle = info.Title;
            info.Title = newTitle;
        }

        public override void UnDo()
        {
            info.Title = oldTitle;
        }

    }
}
