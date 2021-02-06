using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car() {Id=1, BrandId=1, ColorId=5, DailyPrice=100, ModelYear = 2020, Description = "Renault Clio"},
                new Car() {Id=2, BrandId=2, ColorId=1, DailyPrice=120, ModelYear = 2020, Description = "Fiat Egea"},
                new Car() {Id=3, BrandId=3, ColorId=1, DailyPrice=150, ModelYear = 2020, Description = "Ford Focus"},
                new Car() {Id=4, BrandId=4, ColorId=1, DailyPrice=160, ModelYear = 2020, Description = "Toyota Corolla"},
                new Car() {Id=5, BrandId=5, ColorId=1, DailyPrice=200, ModelYear = 2020, Description = "Opel Insignia"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int car_id)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}
