using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.Portfolio = new Dictionary<string, Stock>();
        }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }

        public Dictionary<string, Stock> Portfolio { get; set; }

        public int Count
        {
            get
            {
                return this.Portfolio.Count;
            }
        }

        public void BuyStock(Stock stock)
        {
            if (!this.Portfolio.ContainsKey(stock.CompanyName)
                && stock.MarketCapitalization > 10000
                && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.Portfolio.Add(stock.CompanyName, stock);

                this.MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!this.Portfolio.ContainsKey(companyName))
            {
                return $"{companyName} does not exist.";
            }
            else if (sellPrice < this.Portfolio[companyName].PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            this.Portfolio.Remove(companyName);

            this.MoneyToInvest += sellPrice;

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName) => this.Portfolio.FirstOrDefault(kvp => kvp.Key == companyName).Value;

        public Stock FindBiggestCompany() => this.Portfolio.OrderByDescending(kvp => kvp.Value.MarketCapitalization).FirstOrDefault().Value;

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");

            foreach (var kvp in this.Portfolio)
            {
                sb.AppendLine(kvp.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
