using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryDal:ICarDal
    {
        List<Car> _cars;
        public InMemoryDal()
        {
            _cars = new List<Car>()
            {
                new Car{CarId=1,CarName="BMWW",BrandId=1,ColourId=1,DailyPrice=1500,ModelYear=1995,Descriptions="1.5 Tdi"},
                new Car{CarId=2,CarName="Ferrari",BrandId=2,ColourId=1,DailyPrice=5000,ModelYear=2010,Descriptions="1.5Tdi"},
                new Car{CarId=3,CarName="Audi",BrandId=3,ColourId=2,DailyPrice=1250,ModelYear=1995,Descriptions="1.5 Tdi"},
                new Car{CarId=4,CarName="Fiat",BrandId=4,ColourId=2,DailyPrice=1000,ModelYear=2005,Descriptions="1.6 Egea"},
            };
        }

        public void Add(Car cars)
        {
            _cars.Add(cars);
        }

        public void Delete(Car cars)
        {
            Car carsToDelete = _cars.SingleOrDefault(c => cars.CarId == c.CarId);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrandColor(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetAllByCarsColor(int colorId)
        {
            return _cars.Where(c => c.ColourId == colorId).ToList();
        }

        public List<Car> GetAllCars()
        {
            return _cars;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car cars)
        {
            Car carsToUpdate = _cars.SingleOrDefault(c => cars.CarId == c.CarId);
            carsToUpdate.CarId = cars.CarId;
            carsToUpdate.CarName = cars.CarName;
            carsToUpdate.BrandId = cars.BrandId;
            carsToUpdate.ColourId = cars.ColourId;
            carsToUpdate.DailyPrice = cars.DailyPrice;
            carsToUpdate.ModelYear = cars.ModelYear;
            carsToUpdate.Descriptions = cars.Descriptions;

        }
    }
}
