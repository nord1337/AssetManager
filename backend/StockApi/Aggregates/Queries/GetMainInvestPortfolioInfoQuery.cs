using MediatR;
using StockApi.Data;

namespace StockApi.Aggregates.Queries
{
    public record GetMainInvestPortfolioInfoQuery() : IRequest<GetMainInvestPortfolioInfoResponse>;

    public record GetMainInvestPortfolioInfoResponse(decimal TotalAssetsValue, decimal ProfitMoney, double ProfitPercent);

    public class GetMainInvestPortfolioInfoQueryHandler : IRequestHandler<GetMainInvestPortfolioInfoQuery, GetMainInvestPortfolioInfoResponse>
    {
        private readonly TestDbContext _context;

        public GetMainInvestPortfolioInfoQueryHandler(TestDbContext context)
        {
            _context = context;
        }

        public async Task<GetMainInvestPortfolioInfoResponse> Handle(GetMainInvestPortfolioInfoQuery request, CancellationToken cancellationToken)
        {
            var assets = _context.Assets.ToArray();
            var totalBoughValue = assets.Sum(x => x.BoughtPrice);

            var totalAssetsValue = assets.Sum(x => x.CurrentPrice);
            var profitMoney = totalAssetsValue - totalBoughValue;
            var profitPercent = ((totalAssetsValue - totalBoughValue) / totalBoughValue) * 100;

            return new GetMainInvestPortfolioInfoResponse(totalAssetsValue, profitMoney, (double)profitPercent);
        }
    }
}
