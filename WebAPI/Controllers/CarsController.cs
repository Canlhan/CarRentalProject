using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
            Console.WriteLine("lkasdjajjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj");
            var result = _carService.GetAll();
            if (result.succces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getdetail")]
        public IActionResult GetDetail()
        {
            var result = _carService.GetDetail();
            if (result.succces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.succces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getbycolorid")]
        public IActionResult GetByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.succces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int carId)
        {
            
            var result = _carService.Get(carId);
            if (result.succces)
            {
                return Ok(result);
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
