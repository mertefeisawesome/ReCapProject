using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            

            Console.WriteLine("Araç Listesi: \n");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Marka: " + brandManager.GetById(car.BrandId).Name);
                Console.WriteLine("Model: " + car.Description);
                Console.WriteLine("Renk: " + colorManager.GetById(car.ColorId).Name);
                Console.WriteLine("Model Yılı: " + car.ModelYear);
                Console.WriteLine("Günlük Ücret: " + car.DailyPrice);
                Console.WriteLine("\n");
            }
            Console.WriteLine("----------------------------------------------\n");

            Console.WriteLine("Beyaz Araçlar: \n");
            foreach (var car in carManager.GetCarsByColorId(9))
            {
                Console.WriteLine("Marka: " + brandManager.GetById(car.BrandId).Name);
                Console.WriteLine("Model: " + car.Description);
                Console.WriteLine("Renk: " + colorManager.GetById(car.ColorId).Name);
                Console.WriteLine("Model Yılı: " + car.ModelYear);
                Console.WriteLine("Günlük Ücret: " + car.DailyPrice);
                Console.WriteLine("\n");
            }
            Console.WriteLine("----------------------------------------------\n");

            //araç ekleme
            carManager.Add(new Car { Id = 6, BrandId = 1, ColorId = 1, Description = "a", DailyPrice = 0, ModelYear = 2020 });
            carManager.Add(new Car { Id = 6, BrandId = 1, ColorId = 1, Description = "Fluence", DailyPrice = 0, ModelYear = 2020 });
            carManager.Add(new Car { Id = 6, BrandId = 1, ColorId = 1, Description = "Fluence", DailyPrice = 120, ModelYear = 2020 });

            //bakalım araç veritabanına eklenmiş mi
            Car car6 = carManager.GetById(6);
            Console.WriteLine("Yeni eklenen aracın bilgileri: \n");
            Console.WriteLine("Marka: " + brandManager.GetById(car6.BrandId).Name);
            Console.WriteLine("Model: " + car6.Description);
            Console.WriteLine("Renk: " + colorManager.GetById(car6.ColorId).Name);
            Console.WriteLine("Model Yılı: " + car6.ModelYear);
            Console.WriteLine("Günlük Ücret: " + car6.DailyPrice);
            Console.WriteLine("\n");
        }
    }
}
