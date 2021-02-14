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
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _customerService.GetALL();
            if (result.succces)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }

        [HttpPost("addcustomer")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.succces)
            {
                return Ok(result.message);
            }

            return BadRequest(result.message);
        }
    }
}
