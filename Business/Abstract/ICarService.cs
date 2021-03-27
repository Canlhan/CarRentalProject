using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> Get(int carId);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int id);

        IResult Add(Car car);
        IResult AddImageToCar(Image  image);
        IResult update(Car car);
        IResult delete(Car car);
        IDataResult<List<CarDetailDto>> GetDetail();
      
    }
}
