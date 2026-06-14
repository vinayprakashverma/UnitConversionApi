using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitConversionApi.Models;
using UnitConversionApi.Services;

namespace UnitConversionApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _service;

        public ConversionController(
            IConversionService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(
            typeof(ConversionResponse),
            StatusCodes.Status200OK)]
        public IActionResult Convert(
            [FromBody] ConversionRequest request)
        {
            var result =
                _service.Convert(request);

            return Ok(result);
        }

        [HttpGet("units")]
        public IActionResult GetUnits()
        {
            return Ok(
                _service.GetSupportedUnits());
        }
    }
}
