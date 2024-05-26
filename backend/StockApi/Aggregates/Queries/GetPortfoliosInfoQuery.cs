using MediatR;
using Microsoft.EntityFrameworkCore;
using StockApi.Data;
using StockApi.Data.Models;
using Tinkoff.InvestApi;

namespace StockApi.Aggregates.Queries
{
    public record GetPortfoliosInfoQuery() : IRequest<GetPortfoliosInfoResponse>;

    public class GetPortfoliosInfoResponse
    {
        public IEnumerable<PortfolioInfoDto> PortfoliosInfo { get; set; }
    }

    public class PortfolioInfoDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string About { get; set; }

        public IEnumerable<GrouppedAssetDto> GrouppedAssets { get; set; }
    }

    public class GrouppedAssetDto
    {
        public AssetTypeEnum Type { get; set; }

        public string TypeName { get; set; }

        public int Count { get; set; }

        public string Name { get; set; }

        public string Ticker { get; set; }

        public decimal AveragePrice { get; set; }
        
        public decimal BoughtPriceTotal { get; set; }

        public decimal CurrentPriceTotal { get; set; }

        public decimal Profit { get; set; }

        public decimal ProfitPercent { get; set; }

        public decimal ShareInPortfolio { get; set; }

        public string LogoPath { get; set; }

        public IEnumerable<AssetDto> Assets { get; set; }
    }

    public class AssetDto
    {
        public int Id { get; set; }

        public DateTime BuyDate { get; set; }

        public decimal BoughtPrice { get; set; }
    }

    public class GetPortfoliosInfoQueryHandler : IRequestHandler<GetPortfoliosInfoQuery, GetPortfoliosInfoResponse>
    {
        private readonly TestDbContext _context;
        private readonly InvestApiClient _investApiClient;
        public GetPortfoliosInfoQueryHandler(
            TestDbContext context,
            InvestApiClient investApiClient)
        {
            _context = context;
            _investApiClient = investApiClient;
        }

        public async Task<GetPortfoliosInfoResponse> Handle(GetPortfoliosInfoQuery request, CancellationToken cancellationToken)
        {
            var portfolios = _context.InvestPortfolios
                .Include(x => x.Assets)
                .ToArray();

            var portfoliosInfoDto = portfolios.Select(x => new PortfolioInfoDto
            {
                Id = x.Id,
                Name = x.Name,
                About = x.About,
                GrouppedAssets = x.Assets
                    .GroupBy(y => y.Name)
                    .Select(z =>
                    {
                        var firstAsset = z.First();

                        var totalPortfolioPrice = x.Assets.Sum(x => x.CurrentPrice);

                        var totalPriceCurrent = z.Sum(x => x.CurrentPrice);
                        var totalPriceBought = z.Sum(x => x.BoughtPrice);

                        return new GrouppedAssetDto
                        {
                            Type = firstAsset.Type,
                            TypeName = firstAsset.Type.GetStringName(),
                            Ticker = firstAsset.Ticker ?? "-",
                            Name = firstAsset.Name,
                            Count = z.Count(),
                            AveragePrice = totalPriceCurrent / z.Count(),
                            BoughtPriceTotal = totalPriceBought,
                            Profit = totalPriceCurrent - totalPriceBought,
                            ProfitPercent = ((totalPriceCurrent - totalPriceBought) / totalPriceBought) * 100,
                            ShareInPortfolio = (totalPriceCurrent / totalPortfolioPrice) * 100,
                            CurrentPriceTotal = totalPriceCurrent,
                            LogoPath = firstAsset.LogoImagePath,
                            Assets = z.Select(x => new AssetDto { Id = x.Id, BoughtPrice = x.BoughtPrice, BuyDate = x.BuyDate })
                        };
                    })
            });

            return new GetPortfoliosInfoResponse() { PortfoliosInfo = portfoliosInfoDto.OrderBy(x => x.Id) };
        }
    }
}
