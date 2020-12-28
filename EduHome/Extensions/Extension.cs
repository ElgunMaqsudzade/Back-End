using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Extension
{
    public static class Extension
    {
        public static int PaginationCount(this double dbreturncount , int itemCount)
        {
            double dbcount = (double)Math.Round((double)(dbreturncount / itemCount), 1);
            int count = (int)Math.Ceiling(dbcount);
            return count;
        }
    }
}
