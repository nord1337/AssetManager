using MediatR;
using StockApi.Data;
using StockApi.Data.Entities;

namespace StockApi.Aggregates.Commands
{
    public record AddPortfolioCommand(string PorftolioName, string About) : IRequest<Unit>;

    public class AddPortfolioCommandHandler : IRequestHandler<AddPortfolioCommand, Unit>
    {
        private readonly TestDbContext _context;
        public AddPortfolioCommandHandler(TestDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddPortfolioCommand command, CancellationToken cancellationToken)
        {
            var portfolio = new InvestPortfolio { About = command.About, Name = command.PorftolioName };

            _context.InvestPortfolios.Add(portfolio);
            _context.SaveChanges();

            return Unit.Value;
        }
    }
}
