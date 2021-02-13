using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
   public class RentalManager:IRentalService
    {
        public IDataResult<List<Rental>> GetALL()
        {
            throw new NotImplementedException();
        }

        public IResult Add(Rental car)
        {
            throw new NotImplementedException();
        }

        public IResult update(Rental car)
        {
            throw new NotImplementedException();
        }

        public IResult delete(Rental car)
        {
            throw new NotImplementedException();
        }
    }
}
