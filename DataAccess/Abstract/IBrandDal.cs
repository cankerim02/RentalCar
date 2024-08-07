using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBrandDal : IEntityRepository<Brand>
    {
        //// bütün brand listeleme ve getirme

        //List<Brand> GetAll();
        //void Add(Brand brand);
        //void Update(Brand brand);
        //void Delete(Brand brand);

        ////ürünleri category listele
        //List<Brand> GetAllByCategory(int BrandId);
    }
}
