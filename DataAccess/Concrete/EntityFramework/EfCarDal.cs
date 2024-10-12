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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentalCarContext rentalContext = new RentalCarContext())
            {
                var result = from c in rentalContext.Cars
                             join cl in rentalContext.Colours
                             on c.ColourId equals cl.ColourId
                             join b in rentalContext.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColourName = cl.ColourName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice

                             };
                // Bu noktada sorgu henüz çalıştırılmamıştır
                return result.ToList(); // Burada sorgu çalıştırılır ve sonuçlar elde edilir

                // Bilgi: 

                //IQueryable, sorguyu hemen yürütmez. Sorgu tanımlandıktan sonra, sonuçlara erişilene kadar
                //(örneğin ToList(), FirstOrDefault() gibi metodlar çağrılana kadar) sorgu yürütülmez.



            }
        }

        public List<CarDetailDto> GetCarDetailsCarId(int carId)
        {
            using (RentalCarContext rentalContext = new RentalCarContext())
            {
                var result = from c in rentalContext.Cars
                             join cl in rentalContext.Colours
                             on c.ColourId equals cl.ColourId
                             join b in rentalContext.Brands
                             on c.BrandId equals b.BrandId
                             where c.CarId == carId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 ColourId = cl.ColourId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColourName = cl.ColourName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Descriptions = c.Descriptions
                                 
                             };
                return result.ToList();
            }
        }
    }
}
