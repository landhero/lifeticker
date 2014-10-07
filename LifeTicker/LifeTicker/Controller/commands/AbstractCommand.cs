using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.zhanghs.lifeticker.controller.commands
{
    abstract class  AbstractCommand
    {
        public abstract void Do();
        public abstract void UnDo();
    }
}
