using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColourManager : IColourService
    {
        private IColourDal _colourDal;
        public ColourManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }
        public void Add(Colour colour)
        {
            _colourDal.Add(colour);
        }

        public void Delete(Colour colour)
        {
            _colourDal.Delete(colour);
        }

        public void Update(Colour colour)
        {
            _colourDal.Update(colour);
        }
    }
}
