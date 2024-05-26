using MediatR;
using StockApi.Data;

namespace StockApi.Aggregates.Commands
{
    public class EditSingleAssetCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DateTime BuyDate { get; set; }

        public decimal Price { get; set; }
    }

    public class EditSingleAssetCommandHandler : IRequestHandler<EditSingleAssetCommand, Unit>
    {
        private readonly TestDbContext _context;
        public EditSingleAssetCommandHandler(TestDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(EditSingleAssetCommand request, CancellationToken cancellationToken)
        {
            var asset = _context.Assets.Where(x => x.Id == request.Id).FirstOrDefault();

            if (asset == null) return Unit.Value;

            asset.BoughtPrice = request.Price;
            asset.BuyDate = request.BuyDate;

            _context.Update(asset);

            _context.SaveChanges();

            return Unit.Value;
        }
    }
}
