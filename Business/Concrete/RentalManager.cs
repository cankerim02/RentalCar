using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Castle.Core.Resource;
using Core.CrossCuttingConcern.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {

            // Mevcut kiralama durumunu kontrol et
            var rentalExist = _rentalDal.Get(r=>r.CarId == rental.CarId && r.ReturnDate ==null);
            if (rentalExist != null)
            {
                return new ErrorResult(Messages.CarNotAvailable);
            }

            ValidationTool.Validate(new RentalsValidator(), rental);
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        { 
            // Rental kaydını getir
            var rentalExist = _rentalDal.Get(r => r.RentalId == rental.RentalId);
            if(rentalExist == null)
            {
                return new ErrorResult(Messages.RentalCarNotFound);
            }
            // Eğer eşleşme varsa silme işlemini yap
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalCarDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId == rentalId));
        }

        public IDataResult<List<RentalCarDetailDto>> GetRentalCarDetails()
        {
            return new SuccessDataResult<List<RentalCarDetailDto>>(_rentalDal.GetRentalCarDetails());
        }

        public IResult Update(Rental rental)
        {
            // Veritabanında güncellenecek aracı bul
            var rentalExist = _rentalDal.Get(r => r.CarId == rental.CarId);
            if (rentalExist == null) 
            {
                return new ErrorResult(Messages.RentalCarNotFound);
            }
            rentalExist.RentDate = rental.RentDate;
            rentalExist.ReturnDate = rental.ReturnDate;
            rentalExist.CustomerId = rental.CustomerId;
            _rentalDal.Update(rentalExist);
            return new SuccessResult(Messages.RentalCarUpdated);
        }
    }
}
