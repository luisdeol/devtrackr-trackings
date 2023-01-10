using DevTrackR.Tracking.Application.Models.InputModels;
using DevTrackR.Tracking.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackR.Tracking.API.Controllers
{
    [ApiController]
    [Route("api/shipping-order-updates")]
    public class ShippingOrderUpdatesController : ControllerBase
    {
        private readonly IShippingOrderUpdateService _service;

        public ShippingOrderUpdatesController(IShippingOrderUpdateService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddShippingOrderUpdateInputModel model)
        {
            await _service.AddUpdate(model);

            return NoContent();
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetAllByCode(string code)
        {
            var viewModel = await _service.GetAllByCode(code);

            return Ok(viewModel);
        }
    }
}
