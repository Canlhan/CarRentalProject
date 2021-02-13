using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface ICustomerService
    {
        IDataResult<List<Customer>> GetALL();



        IResult Add(Customer customer);
        IResult update(Customer customer);
        IResult delete(Customer customer);
    }
}
