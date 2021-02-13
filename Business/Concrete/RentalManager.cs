using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class RentalManager:IRentalService
   {
       private IRentalDal _rentalDal;

       public RentalManager(IRentalDal rentalDal)
       {
           _rentalDal = rentalDal;
       }

       public IDataResult<List<Rental>> GetALL()
       {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());

       }

       

       public IResult Add(Rental rental)
       {
           if (_rentalDal.Get(r=>r.CarId==rental.CarId && r.ReturnDate==null)!=null)
           {
               _rentalDal.Add(rental);

               return new SuccessResult(Messages.EntityAdded);
           }

           return new ErrorResult(Messages.EntityNotAdded);

       }

        public IResult update(Rental rental)
        {
           if (_rentalDal.Get(r => r.Id == rental.Id) != null)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.EntityUptaded);
            }

            return new ErrorResult(Messages.EntityNotFound);
            

        }

      

        public IResult delete(Rental rental)
        {
            if (_rentalDal.Get(r => r.Id == rental.Id) != null)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.EntityDeleted);
            }

            return new ErrorResult(Messages.EntityNotFound);
        }
    }
}
