using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
   public class RentalManager:IRentalService
   {
       private IRentalDal _rentalDal;
       private List<Rental> _rentals;
       public RentalManager(IRentalDal rentalDal)
       {
           _rentalDal = rentalDal;
       }

       public IDataResult<List<Rental>> GetALL()
       {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());

       }

       public IDataResult<List<RentalDetailDto>> GetRentalDetail()
       {
           
           return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
       }


       public IResult Add(Rental rental)
       {
           _rentals = _rentalDal.GetAll(r => r.CarId == rental.CarId);
           if (_rentals.Count(r => r.ReturnDate == null) > 0)
           {
             
               return new ErrorResult(Messages.EntityNotAdded);
            }
           _rentalDal.Add(rental);

           return new SuccessResult(Messages.EntityAdded);
           

          

       }

       //private bool CheckExistingRental(Rental rental)
       //{
       //    var rentals = ;
       //    if (rentals!=null)
       //    {
       //        foreach (var srental in rentals)
       //        {
       //            if (srental.ReturnDate == null)
       //            {
       //                return true;
       //            }


       //        }
       //     }
       //    return false;
       // }
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
