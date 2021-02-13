﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class BrandManager:IBrandService
   {
       private IBrandDal _brandDal;

       public BrandManager(IBrandDal brandDal)
       {
           _brandDal = brandDal;
       }

       public IDataResult<List<Brand>> GetAll()
       {
           return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
       }

        public IDataResult<Brand> GetBrandById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(brand => brand.Id == id));
        }

       

        public IResult Add(Brand brand)
        {
          _brandDal.Add(brand);
          return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(Brand brand)
        {
           _brandDal.Delete(brand);
           return new SuccessResult(Messages.EntityDeleted);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.EntityUptaded);
        }
    }
}