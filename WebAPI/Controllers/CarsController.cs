using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _carService.GetAll();
            if (result.succces)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }

        [HttpPost("addcar")]

        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.succces)
            {
                return Ok(result.message);
            }

            return BadRequest(result.message);
        }
    }
}
