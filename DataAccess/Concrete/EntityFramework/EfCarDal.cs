using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,HomeworkContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (HomeworkContext context = new HomeworkContext())
            {

                var result = from c in context.Cars
                    join r in context.Colors
                        on c.ColorId equals r.Id
                    join b in context.Brands on c.BrandId equals b.Id
                    select new CarDetailDto
                    {
                        BrandName = b.Name,
                        CarName = c.Description,
                        DailyPrice = c.DailyPrice,
                        ColorName = r.Name
                    };

                return result.ToList();

            }
        }
    }
}
