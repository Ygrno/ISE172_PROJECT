using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class QueryMarket
    {
        public string type= "queryMarket";
        public int commodity;
        public QueryMarket(int commodity)
        {
            this.commodity = commodity;
        }
    }
}
