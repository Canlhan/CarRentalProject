using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
         IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetColorById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
        }


        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color brand)
        {
           _colorDal.Add(brand);
           return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(Color brand)
        {
           _colorDal.Delete(brand);
           return new SuccessResult(Messages.EntityDeleted);
        }

        public IResult Update(Color brand)
        {
            _colorDal.Update(brand);
            return new SuccessResult(Messages.EntityUptaded);
        }
    }
}
