using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWSL.Common
{
    internal class SLFunc
    {

        public static void InitSL()
        {
            AppData.Instance.GenYearBatch = GetBatchYear();
        }
        public static string GetBatchYear()
        {
            string year = DateTime.Now.ToString("yy");
            return year+="EO -";
        }

        public static string getyearsave()
        {
            string year = DateTime.Now.ToString("yy");
            return year += "EO-";
        }
    }
}
