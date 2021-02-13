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



        IResult Add(Customer car);
        IResult update(Customer car);
        IResult delete(Customer car);
    }
}
