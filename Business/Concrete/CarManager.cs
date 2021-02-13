using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length>2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.EntityAdded);
            }
            else
            {
                Console.WriteLine("günlük fiyatı 0 dan büyük olamaz ve isim en az 2 harften oluşmalı");
                return new ErrorResult(Messages.EntityNotAdded);
            }
            
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
    }
}
