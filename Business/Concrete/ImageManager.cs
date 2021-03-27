using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

using Core.Utilities.BusinessRules;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Core.Utilities.FileHelpers;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
         ICarService _carService;
        public ImageManager(IImageDal imageDal,ICarService carService)
        {
            _imageDal = imageDal;
            _carService = carService;
            

        }

        public IResult Add(Image image, IFormFile file)
        {
           
            var result = BusinessRule.Run(CheckImageOfCarLimit(image.CarId)); ;
               
            if (result!=null)
            {
                return result;

            }
           
           
            
            image.ImagePath = FileHelper.newPath(file);
            image.Date = DateTime.Now;

           
            _imageDal.Add(image);
            return new SuccessResult();
        }

        public IResult Delete(Image image)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Image>> Get(Image carimage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll());
        }

        public IResult Update(Image image)
        {
            return new SuccessResult();
        }

        public IDataResult<List<Image>> GetImageByCarId(int carId)
        {
            var result = _imageDal.GetAll(i => i.CarId == carId).ToList();

            return new SuccessDataResult<List<Image>>(result);
        }

        private IResult CheckImageOfCarLimit(int carId)
        {
            var result = _imageDal.GetAll(i=>i.CarId==carId);
           
            if(result.Count>4)
            {

                return new ErrorResult(Messages.ImageOfCarLimit);
            }
            return new SuccessResult();
        }

    }
}
