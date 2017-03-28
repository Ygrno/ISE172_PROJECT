using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient;
using MarketClient.Utils;

namespace ConsoleApplication1
{
    class VisualPart
    {
        static void Main(string[] args)
        {
            ServerCommunication communicate = new ServerCommunication();
            Console.WriteLine("1 - Sell request\n2 - Buy request\n3 - Cancel request\n4 - Query sell/buy request\n5 - Query user request\n6 - Query market request\n-1 - exit");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    int price_buy, amount_buy, commodity_buy;
                    Console.WriteLine("Enter Price");
                    price_buy = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Amount");
                    amount_buy = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Commodity");
                    commodity_buy = int.Parse(Console.ReadLine());
                    Console.WriteLine("Your ID Number is: " + communicate.SendSellRequest(price_buy, commodity_buy, amount_buy));
                    Console.ReadLine();
                    break;                    
                case 2:
                    int price_sell, amount_sell, commodity_sell;
                    Console.WriteLine("Enter Price:");
                    price_sell = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Amount:");
                    amount_sell = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Commodity:");
                    commodity_sell = int.Parse(Console.ReadLine());
                    Console.WriteLine("Your ID Number is- " + communicate.SendBuyRequest(price_sell, commodity_sell, amount_sell));
                    Console.ReadLine();
                    break;
                case 3:
                    int id_cancel;
                    Console.WriteLine("Please Enter the id of the transcation:");
                    id_cancel = int.Parse(Console.ReadLine());
                    bool check = communicate.SendCancelBuySellRequest(id_cancel);
                    if (check == true)
                        Console.WriteLine("The Transcation was cancelled sucssefully");
                    break;
                case 4:
                    int id_QuerySell;
                    Console.WriteLine("Please Enter the id of the transcation:");
                    id_QuerySell = int.Parse(Console.ReadLine());
                    Console.WriteLine(communicate.SendQueryBuySellRequest(id_QuerySell));
                    break;
                case 5:
                    MarketUserData item = (MarketUserData)communicate.SendQueryUserRequest();
                    Dictionary<string, int> d = item.commodities;
                    int j = 1;
                    foreach (var value in d.Values)
                    {  
                        Console.Write("Commodity number:{0} is: {1}",j, value);
                        Console.WriteLine();
                        j++;
                    }
                    Console.WriteLine("Your founds is: "+ item.funds);
                    Console.Write("Requests list is: ");
                    for (int i = 0; i < item.requests.Count; i++)
                    {
                        if(i<(item.requests.Count-1)) Console.Write(item.requests[i] + ",");
                        else Console.Write(item.requests[i]);


                    }
                    break;
                case 6:
                    Console.WriteLine("Please Enter Commodity:");
                    int commodity = int.Parse(Console.ReadLine());
                    MarketCommodityoffer item2 = (MarketCommodityoffer)communicate.SendQueryMarketRequest(commodity);
                    Console.WriteLine("Ask:{0} , Bid{1}", item2.ask, item2.bid);
                    break;
                default:
                    Console.WriteLine("Have a nice day!");
                    break;
            }
            Console.ReadLine();





        }
    }
}
