using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {

        IImageService _imageService;

        public CarImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("addimage")]
       
        public IActionResult Add( [FromForm]IFormFile file,[FromForm] Image carimage )
        {                                                                                                                       
           
           var result=  _imageService.Add(carimage,file);
            if (result.succces)
            {
                return Ok(result.succces);
            }
           
            return BadRequest(result.message);
            
        }
        [HttpPost("update")]

        public IActionResult update([FromForm] IFormFile file, [FromForm] Image carimage)
        {

            var result = _imageService.Get(carimage);
            if (result.succces)
            {
                return Ok();
            }
            return BadRequest(); 
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _imageService.GetAll();
            if (result.succces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getimagebycarid")]
        public IActionResult GetImageByCarId(int carId)
        {

            var result = _imageService.GetImageByCarId(carId);
            if (result.succces)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
