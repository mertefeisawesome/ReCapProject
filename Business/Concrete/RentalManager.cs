using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

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
            CarManager carManager = new CarManager(new EfCarDal());
            if(carManager.GetById(rental.CarId).Data.Availability == true)
            {
                carManager.GetById(rental.CarId).Data.Availability = false;
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarNotAvailable);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int rental_id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rental_id), Messages.RentalsListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
