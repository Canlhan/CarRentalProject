using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,HomeworkContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (HomeworkContext context=new HomeworkContext())
            {
                var result = from r in context.Rentals
                    join car in context.Cars on r.CarId equals car.Id
                    join customer in context.Customers on r.CustomerId equals customer.Id
                    join Color in context.Colors on car.ColorId equals Color.Id
                    join user in context.Users on customer.UserId equals user.Id

                    select new RentalDetailDto
                    {
                        DailyPrice = car.DailyPrice,
                        Description = car.Description,
                        CompanyName = customer.CompanyName,
                        ModelYear = car.ModelYear,
                        RentDate = r.RentDate,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        ReturnDate = r.ReturnDate
                    };
                return result.ToList();
            }
        }
    }
}
