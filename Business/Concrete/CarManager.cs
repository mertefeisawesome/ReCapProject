using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if(car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameTooShort);
            }
            else if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.CarPriceTooLow);
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int car_id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p=>p.Id==car_id),Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brand_id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brand_id), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int color_id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == color_id),Messages.CarsListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new ErrorResult(Messages.CarUpdated);
        }
    }
}
