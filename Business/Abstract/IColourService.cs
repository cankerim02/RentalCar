using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColourService
    {
        void Add(Colour colour);
        void Update(Colour colour);
        void Delete(Colour colour);

        List<Colour> GetAll();

    }
}
