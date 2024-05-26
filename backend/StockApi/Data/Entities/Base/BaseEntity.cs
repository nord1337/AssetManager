using System.ComponentModel.DataAnnotations;

namespace StockApi.Data.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
