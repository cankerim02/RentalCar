
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentalCarContext>, IRentalDal
    {
        public List<RentalCarDetailDto> GetRentalCarDetails()
        {
            using (RentalCarContext rentalContext = new RentalCarContext())
            {

                //var rentals = rentalContext.Rentals.ToList(); // İlk olarak Rentals tablosunu kontrol et
                //var cars = rentalContext.Cars.ToList(); // Cars tablosunu kontrol et
                //var colours = rentalContext.Colours.ToList(); // Colours tablosunu kontrol et
                //var brands = rentalContext.Brands.ToList(); // Brands tablosunu kontrol et
                //var customers = rentalContext.Customers.ToList(); // Customers tablosunu kontrol et
                //var users = rentalContext.Users.ToList(); // Users tablosunu kontrol et

                var result = from r in rentalContext.Rentals
                             join c in rentalContext.Cars on r.CarId equals c.CarId
                             join cl in rentalContext.Colours on c.ColourId equals cl.ColourId
                             join b in rentalContext.Brands on c.BrandId equals b.BrandId
                             join cs in rentalContext.Customers on r.CustomerId equals cs.CustomerId
                             join u in rentalContext.Users on cs.UserId equals u.UserId

                             select new RentalCarDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColourName = cl.ColourName,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                var finalResult = result.ToList(); // Sonuçları kontrol et
                return finalResult;
            }
        }
    }
}
