using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        
        public static string CarAdded = "Araba eklendi";
        public static string CarListed = "Arabalar listelendi.";
        public static string BrandListed= "Markalar listelendi.";
        public static string ColourListed="Renkler listelendi.";
        public static string RentalListed="Kiralık Araçlar Listelendi";
        public static string UserListed="Kullanıcılar Listelendi";
        public static string CustomerListed="Müşteriler Listelendi";
        public static string RentalAdded="Kiralık Araç eklendi.";
        public static string CarNotAvailable="Araç mevcut değil.";
        public static string RentalCarNotFound = "Kiralık Araba Bulunamadı.";
        public static string RentalCarUpdated="Kiralık Araba Güncellendi.";
        public static string RentalCarDeleted="Kiralık Araç Silindi.";
        public static string CarCountOfBrandError= "Bir arabada en fazla 10 marka olabilir.";
        public static string CarNameAlreadyExistsError = "Aynı isimden araç eklenemez.";
        public static string CarImagesAdded="Resim başarıyla yüklendi.";
        public static string CarImagesDeleted = "Resim başarıyla silindi..";
        public static string? AuthorizationDenied="Yetkiniz yok";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Parola yanlış";
        public static string SuccessfulLogin="Başarılı giriş yaptı";
        public static string UserRegistered="Kayıt işlemi başarılı";
        public static string UserAlreadyExists="Kullanıcı mevcut.";
        public static string AccessTokenCreated = "Token Oluşturuldu.";
    }
}
