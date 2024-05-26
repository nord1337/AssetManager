using MediatR;
using StockApi.Data;
using Tinkoff.InvestApi;

namespace StockApi.Aggregates.Queries
{
    public record GetStocksQuery(int Count) : IRequest<Unit>;

    public class GetStocksQueryHandler : IRequestHandler<GetStocksQuery, Unit>
    {
        private readonly TestDbContext _context;
        private readonly InvestApiClient _investApiClient;

        public GetStocksQueryHandler(TestDbContext context, InvestApiClient investApiClient)
        {
            _context = context;
            _investApiClient = investApiClient;
        }

        public async Task<Unit> Handle(GetStocksQuery request, CancellationToken ct)
        {
            var test1 = await _investApiClient.Instruments.FindInstrumentAsync(
                new Tinkoff.InvestApi.V1.FindInstrumentRequest { Query = "РусАгро" },
                cancellationToken: ct
            );
            var test2 = test1.Instruments;

            var test = _context.TestEntities.ToList();
            return Unit.Value;
        }
    }


}
