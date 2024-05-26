using StockApi.Data.Entities.Base;

namespace StockApi.Data.Entities
{
    public class User : BaseEntity
    {
        public Guid UserApiKey { get; set; }

        public string Name { get; set; }

        public ICollection<InvestPortfolio> InvestPortfolios { get; set; }
    }
}
