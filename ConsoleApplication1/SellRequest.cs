using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class SellRequest
    {
        public int price;
        public int amount;
        public int commodity;
        public String type = "sell";
        public SellRequest(int price, int amount, int commodity)
        {
            this.price = price;
            this.amount = amount;
            this.commodity = commodity;
        }
    }

}
