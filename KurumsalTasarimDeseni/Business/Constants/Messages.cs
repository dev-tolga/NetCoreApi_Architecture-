using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    static class Messages
    {
        public static string ProductAdded = "Ürün başarıyla eklendi.";
        public static string ProductDeleted = "Ürün başarıyla silindi.";
        public static string ProductUpdated = "Ürün başarıyla güncellendi.";

        public static string CustomerAdded = "Müşteri başarıyla eklendi.";
        public static string CustomerDeleted = "Müşteri başarıyla silindi.";
        public static string CustomerUpdated = "Müşteri başarıyla güncellendi.";

        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre hatalı.";
        public static string SuccesfulLogin = "Sisteme giriş başarılı.";

        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut.";
        public static string UserRegistered = "Kullanıcı başaıyla kayıt edildi.";
        public static string AccessTokenCreated = "Token başarıyla oluşturuldu.";

        public static string AuthorizationDenied = "Yetkiniz yok.";
    }
}
