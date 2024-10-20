﻿using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        // bunları burdan aldım entity repo koydum sebebi -- generic olusturmak ıstedım.


        //bütün araçları listeleme ve geri getirme
        //List<Car> GetAllCars();
        //void Add(Car cars);
        //void Update(Car cars);
        //void Delete(Car cars);

        //List<Car> GetAllByCarsColor(int colourId);
        //List<Car> GetAllByBrandColor(int brandId);

        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetCarDetailsCarId(int carId);
        List<CarDetailDto> GetCarByColourAndBrand(int colourId, int brandId);

    }
}
