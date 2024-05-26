using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApi.Aggregates.Commands;
using StockApi.Aggregates.Queries;

namespace StockApi.Controllers
{
    [Route("stocks")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StocksController(IMediator mediator) { _mediator = mediator; }

        [HttpGet("allStocks")]
        public async Task<IActionResult> GetAllStocks([FromQuery] GetStocksQuery query)
        {
            await _mediator.Send(query);

            return Ok();
        }

        [HttpGet("mainInfo")]
        public async Task<IActionResult> GetMainInfo()
        {
            var response = await _mediator.Send(new GetMainInvestPortfolioInfoQuery());

            return Ok(response);
        }

        [HttpGet("portfoliosInfoShort")]
        public async Task<IActionResult> GetPortfoliosInfoShortInfo()
        {
            var response = await _mediator.Send(new GetPortfoliosInfoShortQuery());

            return Ok(response);
        }

        [HttpGet("portfoliosInfo")]
        public async Task<IActionResult> GetPortfoliosInfo()
        {
            var response = await _mediator.Send(new GetPortfoliosInfoQuery());

            return Ok(response);
        }

        [HttpPost("addPortfolio")]
        public async Task<IActionResult> AddPortfolio(AddPortfolioCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost("addAsset")]
        public async Task<IActionResult> AddAsset(AddAssetCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost("editAsset")]
        public async Task<IActionResult> EditAsset(EditSingleAssetCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut("deleteAsset")]
        public async Task<IActionResult> DeleteAsset(DeleteAssetCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
