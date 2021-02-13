using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemoryDal
{
    public class InMemoryDal:ICarDal
    {
        private List<Car> _carlist;

        public InMemoryDal()
        {
            _carlist = new List<Car>
            {
                new Car
                {
                    BrandId = 1, ColorId = 1, DailyPrice = 10, Description = "SIFIRhfjfgj temiz", Id = 1, ModelYear = "1999"
                },
                new Car
                {
                    BrandId = 1, ColorId = 2, DailyPrice = 107, Description = "hasarlı temiz", Id = 2,
                    ModelYear = "1999"
                },
                new Car
                {
                    BrandId = 2, ColorId = 1, DailyPrice = 105, Description = "doktordan temiz", Id = 3,
                    ModelYear = "1999"
                },
                new Car
                {
                    BrandId = 2, ColorId = 2, DailyPrice = 104, Description = "yeni gibitemiz", Id = 4,
                    ModelYear = "1999"
                },
                new Car
                {
                    BrandId = 1, ColorId = 2, DailyPrice = 108, Description = "ihtiyaçtan satılık temiz", Id = 5,
                    ModelYear = "1999"
                },
            };
        }
        public List<Car> GetAll()
        {
            return _carlist;
        }

        public Car GetById(int id)
        {
            return _carlist.SingleOrDefault(p => p.Id == id);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _carlist.Add(car);
        }

        public void Update(Car car)
        {
            var updatedCar = _carlist.SingleOrDefault(c => c.Id == car.Id);
            updatedCar.ColorId = car.ColorId;
            updatedCar.ModelYear = car.ModelYear;
            updatedCar.DailyPrice = car.DailyPrice;

        }

        public void Delete(Car car)
        {
            var deletedCar = _carlist.SingleOrDefault(c => c.Id == car.Id);
            _carlist.Remove(deletedCar);
        }
    }
}
