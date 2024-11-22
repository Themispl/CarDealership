using CarDealershipAPI.Core.Abstractions;
using CarDealershipAPI.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipAPI.API
{
    [Route("api/car-categories")]
    [ApiController]
    public class CarCategoryController : ControllerBase
    {
        private readonly ICarCategoryService _carCategoryService;

        public CarCategoryController(ICarCategoryService carCategoryService)
        {
            _carCategoryService = carCategoryService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var carCategories = await _carCategoryService.GetAllAsync(cancellationToken);
            return Ok(carCategories);
        }


        [HttpGet("{id}")]
        [ActionName(nameof(GetAsync))]
        public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var carCategory = await _carCategoryService.GetByIdAsync(id, cancellationToken);
            return Ok(carCategory);
        }


        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] GetMyDataCategoryRequest request, CancellationToken cancellationToken = default)
        {
            var createdCarCategory = await _carCategoryService.InsertAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetAsync), new { id = createdCarCategory.Id }, createdCarCategory);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] MyDataCategoryUpdateRequest request, CancellationToken cancellationToken = default)
        {
            var updatedCarCategory = await _carCategoryService.UpdateAsync(request, cancellationToken);
            return Ok(updatedCarCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _carCategoryService.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}

