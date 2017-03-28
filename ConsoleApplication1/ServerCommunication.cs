using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient;
using MarketClient.DataEntries;

namespace ConsoleApplication1
{
    class ServerCommunication : MarketClient.IMarketClient

    {
        private const string Url = "http://ise172.ise.bgu.ac.il";
        private const string User = "user30";
        private const string PrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
MIICXgIBAAKBgQCWtmbOG8Vr+tkQEzRnpWykuDw/CU69uPJS5Nw1Gi9eXom6a9D4
KIWQvrhArC7aTg1q1A+XgEfKTsz0otqkYtzYgAneHZv4NDThUJerxppWQX+JeQYV
YroimM4wgBd7hV4pAsXE45A6EM5pjW7rSSoAUYyJH8larjUymm4iqSBQSwIDAQAB
AoGBAI66ZPfSQw/0uvZHSbzSY+ZG9/82oFR6PzsTtBuyFaQIYeSjUH6DWaJvi+zr
Y1+oxXojJDT07ogAQod3ZxqA6eXGp301olM1529q/CkqVwwlFr8QTfxbdUL9+Tge
FNlWeoTkXtzFxfZT+p6XybnZ9R7bLaG6UM6btxY46Q/TS/qBAkEAwyyE3tdSev4C
ZGJHbEjPEK6o6rWClhfElhn4xW/3ncxxYUQXLpk8MXuZv03qn5g6LmZ59SwgsPH2
KAPMMXmtiwJBAMWuowkj/7YX6M7RUEeoTC2MswGtsbl+OHZeQAoGuFQIen6y/BYK
eOZ3usnCcOavcqkEp1PAdch1mmqB1D2ZwEECQDXKOTxpP5QiGWqtI14WmurQGEHH
kJvpJQbxVXykpSvaQo06BOGU3eANXow43ybo/2/2Ujpd1QyvQtY4Zbhk/o0CQQC1
/PZfPeL2EsDjVdOghJHNBVDu5KdPa6IzZsVx9YnQ4xVSexiUegOfuO4fPICP/0mB
zKT296H3cD0+fFOWemuBAkEApKUOEddKJFp51eTuxoIRTGyqFnBIuVhzsa17GiQ8
0cIu7c2z1VplPld/GQOD1R+7RwQwVsG6TmXWID2C5j/4yA==
-----END RSA PRIVATE KEY-----";
        private SimpleHTTPClient client = new SimpleHTTPClient();
        private string token = MarketClient.Utils.SimpleCtyptoLibrary.CreateToken(User, PrivateKey);

        public int SendBuyRequest(int price, int commodity, int amount)
        {
            BuyRequest item = new BuyRequest(price, commodity, amount);
            string response = client.SendPostRequest(Url, User, token, item);
            int num = -1;
            if (response == "No price or commodity type/amount" || response == "Bad commodity" || response == "Bad amount" || response == "No query id" || response == "No commodity" || response == "No auth key" || response == "No user or auth token" || response == "Verification failure"
                || response == "No type key" || response == "Bad request type" || response == "Id not found" || response == "User does not match" || response == "Insufficient funds" || response == "Insufficient commodity")
                Console.WriteLine(response);
            else num = Int32.Parse(response);
            return num;
        }

        public bool SendCancelBuySellRequest(int id)
        {
            Cancel_request item = new Cancel_request(id);
            string response = client.SendPostRequest(Url, User, token, item);
            bool check;
            if (response == "No price or commodity type/amount" || response == "Bad commodity" || response == "Bad amount" || response == "No query id" || response == "No commodity" || response == "No auth key" || response == "No user or auth token" || response == "Verification failure"
                || response == "No type key" || response == "Bad request type" || response == "Id not found" || response == "User does not match" || response == "Insufficient funds" || response == "Insufficient commodity")
                Console.WriteLine(response);
            check = response == "Ok";
            return check;
        }

        public IMarketItemQuery SendQueryBuySellRequest(int id)
        {
            QueryBuySell item = new QueryBuySell(id);


            MarketItemQuery response = new MarketItemQuery(item);

            return response;



        }

        public IMarketCommodityOffer SendQueryMarketRequest(int commodity)
        {
            QueryMarket item = new QueryMarket(commodity);
            MarketCommodityoffer response = new MarketCommodityoffer(item);
            return response;

        }

        public IMarketUserData SendQueryUserRequest()
        {
            MarketUserData item = new MarketUserData();
            item.Builder();
            return item;
        }

        public int SendSellRequest(int price, int commodity, int amount)
        {
            SellRequest item = new SellRequest(price, commodity, amount);
            string response = client.SendPostRequest(Url, User, token, item);
            int num = -1;
            if (response == "No price or commodity type/amount" || response == "Bad commodity" || response == "Bad amount" || response == "No query id" || response == "No commodity" || response == "No auth key" || response == "No user or auth token" || response == "Verification failure"
                || response == "No type key" || response == "Bad request type" || response == "Id not found" || response == "User does not match" || response == "Insufficient funds" || response == "Insufficient commodity")
                Console.WriteLine(response);
            else num = Int32.Parse(response);
            return num;
        }
    }
}

