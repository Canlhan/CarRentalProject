using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
  public  class CarManager:ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
        public IDataResult<List<CarDetailDto>> Get(int carId)
        {
            var car = _carDal.GetCarDetail(c => c.Id == carId);

            return new SuccessDataResult<List<CarDetailDto>>(car);
        }

       

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(c=>c.BrandId==id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(c=>c.ColorId==id));
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            

            ValidationTools.Validate(new CarValidator(),car);

           _carDal.Add(car);
           return new SuccessResult(Messages.EntityAdded);



        }

        public IResult AddImageToCar(Image image)
        {
            throw new NotImplementedException();
        }

        public IResult update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.EntityUptaded);
        }

        public IResult delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<CarDetailDto>> GetDetail()
        {

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail());
        }

      } 
      
    
}
