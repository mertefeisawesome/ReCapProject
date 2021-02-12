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
            //CarTest();

            //ColorTest();

            //BrandTest();

            //UserTest();

            Console.WriteLine(new RentalManager(new EfRentalDal()).Add(new Rental { CarId = 2, CustomerId = 2, Id = 2, RentDate = new DateTime(2021, 2, 12) }).Message);

        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            Console.WriteLine("Kullanıcı Listesi: \n");
            foreach (User user in userManager.GetAll().Data)
            {
                Console.WriteLine("Id: " + user.Id);
                Console.WriteLine("İsim Soyisim: " + user.FirstName + " " + user.LastName);
                Console.WriteLine("\n");
            }
            Console.WriteLine("----------------------------------------------\n");

            //kullanıcı ekleme
            userManager.Add(new User { Id = 750, FirstName = "Engin", LastName="Demiroğ", Email="engin@kodlama.io", Password="1234" });

            //bakalım kullanıcı veritabanına eklenmiş mi
            User testUser = userManager.GetById(750).Data;
            Console.WriteLine("Yeni eklenen kullanıcının bilgileri: \n");
            Console.WriteLine("Id: " + testUser.Id);
            Console.WriteLine("İsim Soyisim:  " + testUser.FirstName);
            Console.WriteLine("\n");

            //kullanıcı güncelleme
            testUser.LastName = "Terzi";
            userManager.Update(testUser);
            Console.WriteLine("Güncellenen kullanıcının yeni bilgileri: \n");
            Console.WriteLine("Id: " + testUser.Id);
            Console.WriteLine("İsim Soyisim: " + testUser.FirstName + " " + testUser.LastName);

            //kullanıcı silme
            userManager.Delete(testUser);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("Marka Listesi: \n");
            foreach (Brand brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("Id: " + brand.Id);
                Console.WriteLine("Marka: " + brand.Name);
                Console.WriteLine("\n");
            }
            Console.WriteLine("----------------------------------------------\n");

            //marka ekleme
            brandManager.Add(new Brand { Id = 750, Name = "Tesla" });

            //bakalım marka veritabanına eklenmiş mi
            Brand testBrand = brandManager.GetById(750).Data;
            Console.WriteLine("Yeni eklenen markanın bilgileri: \n");
            Console.WriteLine("Id: " + testBrand.Id);
            Console.WriteLine("Marka: " + testBrand.Name);
            Console.WriteLine("\n");

            //marka güncelleme
            testBrand.Name = "Anadol";
            brandManager.Update(testBrand);
            Console.WriteLine("Güncellenen markanın yeni bilgileri: \n");
            Console.WriteLine("Id: " + testBrand.Id);
            Console.WriteLine("Marka: " + testBrand.Name);

            //marka silme
            brandManager.Delete(testBrand);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("Renk Listesi: \n");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("Id: " + color.Id);
                Console.WriteLine("Renk: " + color.Name);
                Console.WriteLine("\n");
            }
            Console.WriteLine("----------------------------------------------\n");

            //renk ekleme
            colorManager.Add(new Color { Id = 750, Name = "Oranj" });

            //bakalım renk veritabanına eklenmiş mi
            Color testColor = colorManager.GetById(750).Data;
            Console.WriteLine("Yeni eklenen rengin bilgileri: \n");
            Console.WriteLine("Id: " + testColor.Id);
            Console.WriteLine("Renk: " + testColor.Name);
            Console.WriteLine("\n");

            //renk güncelleme
            testColor.Name = "Altın Sarısı";
            colorManager.Update(testColor);
            Console.WriteLine("Güncellenen rengin yeni bilgileri: \n");
            Console.WriteLine("Id: " + testColor.Id);
            Console.WriteLine("Renk: " + testColor.Name);

            //renk silme
            colorManager.Delete(testColor);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());


            Console.WriteLine("Araç Listesi: \n");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Marka: " + car.BrandName);
                Console.WriteLine("Model: " + car.CarName);
                Console.WriteLine("Renk: " + car.ColorName);
                Console.WriteLine("Model Yılı: " + car.ModelYear);
                Console.WriteLine("Günlük Ücret: " + car.DailyPrice);
                Console.WriteLine("\n");
            }
            Console.WriteLine("----------------------------------------------\n");

            //araç ekleme
            carManager.Add(new Car { Id = 6, BrandId = 1, ColorId = 1, CarName = "a", DailyPrice = 0, ModelYear = 2020 });
            carManager.Add(new Car { Id = 6, BrandId = 1, ColorId = 1, CarName = "Fluence", DailyPrice = 0, ModelYear = 2020 });
            carManager.Add(new Car { Id = 6, BrandId = 1, ColorId = 1, CarName = "Fluence", DailyPrice = 120, ModelYear = 2020 });

            //bakalım araç veritabanına eklenmiş mi
            Car car6 = carManager.GetById(6).Data;
            Console.WriteLine("Yeni eklenen aracın bilgileri: \n");
            Console.WriteLine("Marka: " + brandManager.GetById(car6.BrandId).Data.Name);
            Console.WriteLine("Model: " + car6.CarName);
            Console.WriteLine("Renk: " + colorManager.GetById(car6.ColorId).Data.Name);
            Console.WriteLine("Model Yılı: " + car6.ModelYear);
            Console.WriteLine("Günlük Ücret: " + car6.DailyPrice);
            Console.WriteLine("\n");

            //araç güncelleme
            car6.CarName = "Megane";
            carManager.Update(car6);
            Console.WriteLine("Güncellenen aracın yeni bilgileri: \n");
            Console.WriteLine("Marka: " + brandManager.GetById(car6.BrandId).Data.Name);
            Console.WriteLine("Model: " + car6.CarName);

            //araç silme
            carManager.Delete(car6);
        }
    }
}
