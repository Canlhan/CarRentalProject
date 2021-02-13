using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        public IDataResult<List<User>> GetALL()
        {
            return null;
        }

        public IResult Add(User car)
        {
            throw new NotImplementedException();
        }

        public IResult update(User car)
        {
            throw new NotImplementedException();
        }

        public IResult delete(User car)
        {
            throw new NotImplementedException();
        }
    }
}
