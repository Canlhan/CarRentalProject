using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public  interface IImageService
    {
        IDataResult<List<Image>> GetAll();
        IDataResult<List<Image>> Get(Image carimage);


        IResult Add(Image image, IFormFile file);
        IResult Delete(Image image);

        IResult Update(Image image);
        IDataResult<List<Image>> GetImageByCarId(int carId);
    }
}
