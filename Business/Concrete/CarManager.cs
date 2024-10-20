﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcern.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

        [ValidationAspect(typeof(CarsValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(
                CheckIfCarCountOfBrandCorrect(car.BrandId),
                CheckIfCarNameExists(car.CarName));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            //var carToDelete = _carDal.Get(c=>c.CarId == car.CarId);
            //if(carToDelete == null)
            // {
            //     return new ErrorResult();
            // }
            _carDal.Delete(car);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            Thread.Sleep(3000);
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        //[PerformanceAspect(5)]
        public IDataResult<Car> GetByCarId(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsCarId(carId));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsBycolourId(int colourId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColourId == colourId));
        }

        public IDataResult<List<CarDetailDto>> GetCarByColourAndBrand(int colourId, int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarByColourAndBrand(colourId,brandId));
        }

        //[TransactionScopeAspect]
        //public IResult TransctionalOperation(Car car)
        //{
        //    Add(car);
        //    if (car.DailyPrice < 10)
        //    {
        //        throw new Exception("");
        //    }
        //    Add(car);
        //    return null;
        //}

        [ValidationAspect(typeof(CarsValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            var result = _carDal.GetAll(c => c.BrandId == car.BrandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            _carDal.Update(car);
            return new SuccessResult();
        }
        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarNameExists(string carName)
        {
            var result = _carDal.GetAll(c => c.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExistsError);
            }
            return new SuccessResult();
        }
    }
}
