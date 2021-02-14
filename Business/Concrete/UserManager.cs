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
    public class UserManager:IUserService
    {
       IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetALL()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult update(User user)
        {
            if (_userDal.Get(u => u.Id == user.Id) != null)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.EntityUptaded);
            }

            return new ErrorResult(Messages.EntityNotFound);
        }

        public IResult delete(User user)
        {
            if (_userDal.Get(u => u.Id == user.Id) != null)
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.EntityDeleted);
            }

            return new ErrorResult(Messages.EntityNotFound);
        }
    }
}
