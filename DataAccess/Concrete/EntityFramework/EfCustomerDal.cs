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
   public class EfCustomerDal:EfEntityRepositoryBase<Customer,HomeworkContext>,ICustomerDal
    {
        public List<CustomerDto> GetCustomerDetail()
        {
            using (HomeworkContext context=new HomeworkContext())
            {
                var result = from c in context.Customers
                    join u in context.Users on c.UserId equals u.Id
                    select new CustomerDto
                    {
                        CompanyName = c.CompanyName,
                        FirstName = u.FirstName,
                        LastName = u.LastName
                    };
                return result.ToList();
            }
        }
    }
}
