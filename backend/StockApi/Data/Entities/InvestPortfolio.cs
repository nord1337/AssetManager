using StockApi.Data.Entities.Base;

namespace StockApi.Data.Entities
{
    public class InvestPortfolio : BaseEntity
    {
        public string Name { get; set; }

        public string About { get; set; }

        public ICollection<Asset> Assets { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
