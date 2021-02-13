using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
   public class CustomerManager:ICustomerService
    {
        public IDataResult<List<Customer>> GetALL()
        {
            throw new NotImplementedException();
        }

        public IResult Add(Customer car)
        {
            throw new NotImplementedException();
        }

        public IResult update(Customer car)
        {
            throw new NotImplementedException();
        }

        public IResult delete(Customer car)
        {
            throw new NotImplementedException();
        }
    }
}
