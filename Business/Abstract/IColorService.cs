using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
     public interface IColorService
    {
        
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetColorById(int id);
        

      IResult Add(Color brand);
      IResult Delete(Color brand);

      IResult Update(Color brand);
    }
}
