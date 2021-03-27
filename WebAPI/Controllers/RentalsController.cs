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
    public class RentalsController : ControllerBase
    {
        private IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("addrental")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.succces)
            {
                return Ok(result.message);
            }

            return BadRequest(result.message);
        }
        [HttpGet("getdetail")]
        public IActionResult GetDetails()
        {
            var result = _rentalService.GetRentalDetail();
            if (result.succces)
            {
                return Ok(result);
            }

            return BadRequest(result.message);
        }
    }
}
