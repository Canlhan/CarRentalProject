﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.succces)
            {
                return Ok(result);
            }

            return BadRequest(result.message);
        }
        [HttpPost("addbrand")]
        public IActionResult Add(Brand brand)
        {
           var result= _brandService.Add(brand);
           if (result.succces)
           {
               return Ok(result.succces);
           }

           return BadRequest(result);
        }
    }
}
