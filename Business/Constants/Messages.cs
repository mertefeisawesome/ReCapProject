using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandsListed = "Markalar listelendi.";

        public static string CarNameTooShort = "Araç ismi minimum 2 karakter olmalıdır.";
        public static string CarPriceTooLow = "Araç fiyatı 0'dan büyük olmalıdır.";
        public static string CarAdded = "Araç eklendi.";
        public static string CarDeleted = "Araç silindi.";
        public static string CarUpdated = "Araç güncellendi.";
        public static string CarsListed = "Araçlar listelendi.";
        public static string CarNotAvailable = "Araç, kiralama için uygun değil.";

        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorsListed = "Renkler listelendi.";

        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomersListed = "Müşteriler listelendi.";

        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UsersListed = "Kullanıcıler listelendi.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola yanlış";
        public static string SuccessfulLogin = "Giriş yapıldı";
        public static string UserAlreadyExists = "Bu mail adresiyle kaydolmuş bir kullanıcı zaten var";
        public static string UserRegistered = "Kullanıcı kaydı başarılı";
        public static string AccessTokenCreated = "Access token oluşturuldu";
        public static string AuthorizationDenied = "Bu işlem için yetkiniz yok";

        public static string RentalAdded = "Araç kiralandı.";
        public static string RentalDeleted = "Araç rezervasyonu silindi.";
        public static string RentalUpdated = "Rezervasyon bilgileri güncellendi.";
        public static string RentalsListed = "Rezervasyonlar listelendi.";

        public static string ImageAdded = "Görsel eklendi";
        public static string ImageUpdated = "Görsel güncellendi";
        public static string ImageDeleted = "Görsel silindi";
        public static string ImagesListed = "Görseller listelendi";
        public static string ImageLimit = "Bir aracın maksimum 5 resmi olabilir";
    }
}