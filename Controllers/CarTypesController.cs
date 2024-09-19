using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CarInventoryAPI.Models;
using CarInventoryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarInventoryAPI.Controllers
{
    [Route("[controller]")]
    public class CarTypesController : Controller
    {
        private readonly ICarTypeSercvice _carTypeService;

        public CarTypesController(ICarTypeSercvice carTypeService)
        {
            _carTypeService = carTypeService;
        }


        /// <summary>
        /// List cars
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<CarTypes>> ListMedicines()
        {
            return await _carTypeService.ListCarTypeAsync();
        }

        /// <summary>
        /// Get car by id
        /// </summary>
         [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<CarTypes> GetCar([FromRoute] Guid id)
        {
            return await _carTypeService.GetCarTypeAsync(id);
        }

        /// <summary>
        /// Create a car
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCar([FromBody] CarTypes car)
        {
            var result = await _carTypeService.CreateCarTypeAsync(car.CarType, car.Quantity, car.IsElectric);

            return StatusCode(StatusCodes.Status201Created, new { CarTypeId = result });    
        }

        /// <summary>
        /// Delete a car
        /// </summary>
        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> DeleteCar([FromRoute] Guid id)
        {
            await _carTypeService.DeleteCarTypeAsync(id);

            return Ok();
        }

        /// <summary>
        /// Update a car
        /// </summary>
        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> UpdateCar([FromRoute] Guid id, [FromBody] CarTypes car)
        {
            await _carTypeService.UpdateCarTypeAsync(id, car.CarType, car.Quantity, car.IsElectric);

            return Ok();
        }
    }
}