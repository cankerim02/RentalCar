

using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using static System.Net.Mime.MediaTypeNames;

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
            //GetCarDetails();

            //UserAddAndGetAll();
            //CustomerGetAll();

            //RentalGetAll();

           // Aracın Müsait Olduğu Durumu Test Etme:
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var result = rentalManager.Add(
            //    new Rental
            //    {
            //        CarId = 12,
            //        RentalId = 7,
            //        CustomerId = 7,
            //        ReturnDate = null, // Henüz iade edilmemiş, yani araç kiralanmış
            //        RentDate = null,   // Kiralama işlemi yapılamaz.

            //    });
            //if (result.Success)
            //{
            //    Console.WriteLine("Rental added successfully");
            //}
            //else { Console.WriteLine(result.Message); } // Bu durumda "CarNotAvailable" mesajını alırsınız.
            var result2 = rentalManager.Add(
                new Rental
                {
                    CarId = 14,
                    RentalId = 8,
                    CustomerId = 8,
                    RentDate = DateTime.Now.AddDays(-1), //  Araç kiralanmış
                    ReturnDate = null, //  Heniz teslim edilmemiş
                });

            if (result2.Success)
            {
                Console.WriteLine("Rental added successfully");
            }
            else { Console.WriteLine("Araç kiralanmış ama henüz teslim edilmemiş"); }
        }

        private static void CustomerGetAll()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(
                new Customer
                {
                    CompanyName = "Test",
                    UserId = 7,
                    CustomerId = 6,
                });
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.UserId + " " + customer.CustomerId + " " + customer.CompanyName);
            }
        }

        private static void RentalGetAll()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(
                new Rental
                {
                    CarId = 11,
                    RentalId = 6,
                    ReturnDate = DateTime.Now,
                    RentDate = DateTime.Now,
                });
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.CarId + " " + rental.RentalId + " " + rental.RentDate + " " + rental.ReturnDate);
            }
        }

        private static void UserAddAndGetAll()
        {
            UserManager userManger = new UserManager(new EfUserDal());

            userManger.Add(
                new User
                {
                    UserId = 6,
                    FirstName = "Joe",
                    LastName = "Jonas",
                    Email = "joe.jonas@example.com",
                    //Passwords = "pass12"
                });
            foreach (var user in userManger.GetAll().Data)
            {
                Console.WriteLine(user.FirstName + "" + user.LastName);
            }
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
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