using MediatR;
using Microsoft.EntityFrameworkCore;
using StockApi.Data;
using System.Xml.Linq;
using Tinkoff.InvestApi;

namespace StockApi.Aggregates.Queries
{
    public record GetPortfoliosInfoShortQuery() : IRequest<GetPortfoliosInfoShortResponse>;

    public class GetPortfoliosInfoShortResponse
    {
        public IEnumerable<InvestPortfolioShortDto> InvestPortfoliosDto { get; set; }
    }

    public record InvestPortfolioShortDto(int Id, string Name, decimal Price, decimal Profit, decimal ProfitPercent, decimal ShareInTotalPortfolio);

    public class GetPortfoliosInfoShortQueryHandler : IRequestHandler<GetPortfoliosInfoShortQuery, GetPortfoliosInfoShortResponse>
    {
        private readonly TestDbContext _context;
        private readonly InvestApiClient _investApiClient;
        public GetPortfoliosInfoShortQueryHandler(
            TestDbContext context,
            InvestApiClient investApiClient)
        {
            _context = context;
            _investApiClient = investApiClient;
        }

        public async Task<GetPortfoliosInfoShortResponse> Handle(GetPortfoliosInfoShortQuery request, CancellationToken cancellationToken)
        {
            var allInvestPortfolios = _context.InvestPortfolios.Include(r => r.Assets).ToArray();
            var totalPortfolioAssetsSum = _context.Assets.Sum(x => x.CurrentPrice);

            var portfoliosShortDtos = allInvestPortfolios.Select(x =>
            {
                var totalAssetSumBoughtPrice = x.Assets.Sum(y => y.BoughtPrice);
                var currentPrices = x.Assets.Sum(y => y.CurrentPrice);

                return new InvestPortfolioShortDto(
                    Id: x.Id,
                    Name: x.Name,
                    Price: x.Assets.Sum(y => y.CurrentPrice),
                    Profit: currentPrices - totalAssetSumBoughtPrice,
                    ProfitPercent: GetProfitPercent(totalAssetSumBoughtPrice, currentPrices),
                    ShareInTotalPortfolio: (currentPrices / totalPortfolioAssetsSum) * 100);
            });

            return new GetPortfoliosInfoShortResponse() { InvestPortfoliosDto = portfoliosShortDtos };
        }

        private static decimal GetProfitPercent(decimal totalAssetSumBoughtPrice, decimal currentPrices)
        {
            if (totalAssetSumBoughtPrice == 0) return 0;

            return ((currentPrices - totalAssetSumBoughtPrice) / totalAssetSumBoughtPrice) * 100;
        }
    }
}
