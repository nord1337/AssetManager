using MediatR;
using StockApi.Data;

namespace StockApi.Aggregates.Commands
{
    public record DeleteAssetCommand(int Id) : IRequest<Unit>;

    public class DeleteAssetCommandHandler : IRequestHandler<DeleteAssetCommand, Unit>
    {
        private readonly TestDbContext _context;

        public DeleteAssetCommandHandler(TestDbContext context) { _context = context; }


        public Task<Unit> Handle(DeleteAssetCommand command, CancellationToken cancellationToken)
        {
            var assetToDelete = _context.Assets.Where(x => x.Id ==  command.Id).FirstOrDefault();

            if (assetToDelete != null)
            {
                _context.Assets.Remove(assetToDelete);
                _context.SaveChanges();
            }

            return Unit.Task;
        }
    }
}
