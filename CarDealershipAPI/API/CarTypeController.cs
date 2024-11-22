using CarDealershipAPI.Core.Abstractions;
using CarDealershipAPI.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipAPI.API
{
    [Route("api/car-types")]
    [ApiController]
    public class CarTypeController : ControllerBase
    {
        private readonly ICarTypeService _carTypeService;
        public CarTypeController(ICarTypeService carTypeService)
        {
            _carTypeService = carTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var carTypes = await _carTypeService.GetAllAsync(cancellationToken);
            return Ok(carTypes);
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetAsync))]
        public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var carType = await _carTypeService.GetByIdAsync(id, cancellationToken);
            return Ok(carType);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] GetMyDataRequest request, CancellationToken cancellationToken = default)
        {
            var createdCarType = await _carTypeService.InsertAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetAsync), new { id = createdCarType.Id }, createdCarType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] MyDataUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var updatedCarType = await _carTypeService.UpdateAsync(request, cancellationToken);
            return Ok(updatedCarType);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _carTypeService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
