using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace ConsoleApplication1
{
    class Cancel_request 
    {
        public string type = "cancelBuySell";
        int id;
        public Cancel_request(int id)
        {
            this.id = id;
        }
    }
}
