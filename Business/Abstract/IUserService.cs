using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetALL();
        
        

        IResult Add(User car);
        IResult update(User car);
        IResult delete(User car);
    }
}
