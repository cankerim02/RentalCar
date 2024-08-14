

using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //InMemoryDal();
            //CarManager();
            //BrandManager();
            //CarBiggerThanTwo();
            //DailyPriceAndCarName();,

            //GetCarsByBrandId();,
            //GetCarsByColorId();
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if(result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColourName + " " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        //private static void GetCarsByColorId()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetCarsByColorId(1))
        //    {
        //        Console.WriteLine(car.CarId + " " + car.CarName + " " + car.ColourId);
        //    }
        //}

        //private static void GetCarsByBrandId()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetCarsByBrandId(1))
        //    {
        //        Console.WriteLine(car.CarName);
        //    }
        //}

        private static void DailyPriceAndCarName()
        {


            //Araba ismi 2 den büyük ve eşit  olanları ve fiyatı 0 dan büyük olanları ekle.
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColourId = 1, DailyPrice = 100, CarName = "H", ModelYear = 2020 });

        }

        //private static void CarBiggerThanTwo()
        //{
        //    //Araba ismi 2 den büyük ve eşit  olanları getirir.
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var item in carManager.GetAll())
        //    {
        //        Console.WriteLine(item.CarName);
        //    }
        //}

        //private static void BrandManager()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    foreach (var brand in brandManager.GetAll())
        //    {
        //        Console.WriteLine(brand.BrandId + " " + brand.BrandName);
        //    }
        //}

        //private static void CarManager()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.WriteLine(car.CarName + " " + car.ModelYear);
        //    }
        //}

        //private static void InMemoryDal()
        //{
        //    CarManager carManager = new CarManager(new InMemoryDal());

        //    var result = new InMemoryDal();

        //    foreach (var cars in result.GetAll())
        //    {
        //        Console.WriteLine(cars.CarName);
        //    }
        //}
    }
}