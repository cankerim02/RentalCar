using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcern.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColourManager : IColourService
    {
        IColourDal _colourDal;
        public ColourManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }
        public IResult Add(Colour colour)
        {
            ValidationTool.Validate(new ColoursValidator(), colour);
            _colourDal.Add(colour);
            return new SuccessResult();
        }

        public IResult Delete(Colour colour)
        {
            _colourDal.Delete(colour);
            return new SuccessResult();
        }

        public IDataResult<List<Colour>> GetAll()
        {
            return new SuccessDataResult<List<Colour>>(_colourDal.GetAll(),Messages.ColourListed);
        }

        public IResult Update(Colour colour)
        {
            _colourDal.Update(colour);
            return new SuccessResult();
        }
    }
}
