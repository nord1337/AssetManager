using StockApi.Data.Entities.Base;
using StockApi.Data.Models;

namespace StockApi.Data.Entities
{
    public class Asset : BaseEntity
    {
        public DateTime BuyDate { get; set; }

        public string Name { get; set; }

        public string Ticker { get; set; }

        public decimal BoughtPrice { get; set; }

        public decimal CurrentPrice { get; set; }

        public AssetTypeEnum Type { get; set; }

        public int InvestPortfolioId { get; set; }

        public InvestPortfolio InvestPortfolio { get; set; }

        public string TinkoffApiAssetId { get; set; }

        public string LogoImagePath { get; set; }
    }
}
