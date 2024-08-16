using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult Add(Car car)
        {
            if(car.CarName.Length >= 2 && car.DailyPrice > 0)
            {
                return new SuccessResult(Messages.CarAdded);

            }
            return new ErrorResult("Araba ismi minimum 2 karakter olmalıdır ve günlük fiyatı 0'dan büyük olmalıdır.");
            
        }

        public IResult Delete(Car car)
        {
           var carToDelete = _carDal.Get(c=>c.CarId == car.CarId);
           if(carToDelete == null)
            {
                return new ErrorResult();
            }
            _carDal.Delete(carToDelete);
           return  new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
           return new SuccessDataResult<List<Car>>(_carDal.GetAll().Where(c=>c.CarName.Length >= 2).ToList(),Messages.CarListed);
        }

        public IDataResult<Car> GetByCarId(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),true);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId),true);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(c => c.ColourId == colorId),true);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

    }
}
