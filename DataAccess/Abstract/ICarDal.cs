using Core.DataAccess.EntityFramework;
using Entities.Concrete;
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

        //List<Car> GetAllByCarsColor(int colorId);
        //List<Car> GetAllByBrandColor(int brandId);

        

    }
}
