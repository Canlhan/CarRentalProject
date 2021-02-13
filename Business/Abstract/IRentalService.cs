using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IRentalService
    {
        IDataResult<List<Rental>> GetALL();



        IResult Add(Rental car);
        IResult update(Rental car);
        IResult delete(Rental car);
    }
}
