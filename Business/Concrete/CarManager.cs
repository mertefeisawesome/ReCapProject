using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public void Add(Car car)
        {
            if(car.Description.Length < 2)
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır.");
            }
            else if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır.");
            }
            else
            {
                _carDal.Add(car);
            }
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int car_id)
        {
            return _carDal.Get(p=>p.Id==car_id);
        }

        public List<Car> GetCarsByBrandId(int brand_id)
        {
            return _carDal.GetAll(p => p.BrandId == brand_id);
        }

        public List<Car> GetCarsByColorId(int color_id)
        {
            return _carDal.GetAll(p => p.ColorId == color_id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
