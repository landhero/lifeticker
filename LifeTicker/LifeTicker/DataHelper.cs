using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTicker
{
    class DataHelper
    {
        public static String DATA_DIR = "D:\\weiyun\\notes\\lifeticker\\";
        public static LinkedList<IssueInfo> getIssueInfos() {
            String path_issuse = DATA_DIR + "issus.json";
            LinkedList<IssueInfo> rlt = new LinkedList<IssueInfo>();
            IssueInfo ii1= new IssueInfo();
            ii1.Title = "Testsdfasdfad01";
            rlt.AddLast(ii1);
            IssueInfo ii2 = new IssueInfo();
            ii2.Title = "test02";
            rlt.AddLast(ii2);
            return rlt;
        }
    }
}
