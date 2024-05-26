using MediatR;
using StockApi.Data;
using StockApi.Data.Entities;
using StockApi.Data.Models;

namespace StockApi.Aggregates.Commands
{
    public class AddAssetCommand : IRequest<Unit>
    {
        public int Count { get; set; } = 1;

        public DateTime BuyDate { get; set; }

        public string Name { get; set; }

        public string? Ticker { get; set; }

        public AssetTypeEnum Type { get; set; }

        public int InvestPortfolioId { get; set; }

        public decimal BoughtPrice { get; set; }

        public decimal CurrentPrice { get; set; }
    }

    public class AddAssetCommandHandler : IRequestHandler<AddAssetCommand, Unit>
    {
        private readonly TestDbContext _context;

        public AddAssetCommandHandler(TestDbContext context) { _context = context;  }

        public async Task<Unit> Handle(AddAssetCommand command, CancellationToken cancellationToken)
        {
            var assets = Enumerable.Range(0, command.Count).Select(x =>  new Asset
            {
                BoughtPrice = command.BoughtPrice,
                CurrentPrice = command.CurrentPrice,
                BuyDate = command.BuyDate,
                Name = command.Name,
                Ticker = command.Ticker,
                Type = command.Type,
                InvestPortfolioId = command.InvestPortfolioId,
            });

            _context.Assets.AddRange(assets);

            _context.SaveChanges();

            return Unit.Value;
        }
    }
}
