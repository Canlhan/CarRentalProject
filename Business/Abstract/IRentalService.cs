using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IRentalService
    {
        IDataResult<List<Rental>> GetALL();


        
        IResult Add(Rental rental);
        IResult update(Rental rental);
        IResult delete(Rental rental);
    }
}
