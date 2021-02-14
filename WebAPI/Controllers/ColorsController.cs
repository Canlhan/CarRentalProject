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
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _colorService.GetAll();
            if (result.succces)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.message);
        }
        [HttpPost("addcolor")]
        public IActionResult Get(Color color)
        {
            var result = _colorService.Add(color);
            if (result.succces)
            {
                return Ok(result.message);
            }

            return BadRequest(result.message);
        }
    }
}
