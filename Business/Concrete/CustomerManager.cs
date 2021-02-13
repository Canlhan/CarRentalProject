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
   public class CustomerManager:ICustomerService
   {
       private ICustomerDal _customerDal;

       public CustomerManager(ICustomerDal customerDal)
       {
           _customerDal = customerDal;
       }

       public IDataResult<List<Customer>> GetALL()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());

        }

        public IResult Add(Customer customer)
        {
            if (_customerDal.Get(c => c.Id == customer.Id) == null)
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.EntityAdded+);
            }

            return new ErrorResult(Messages.EntityNotFound);
        }

        public IResult update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IResult delete(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
