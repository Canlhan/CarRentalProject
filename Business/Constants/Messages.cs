using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string EntityAdded = " nesne eklendi";
        public static string EntityNotAdded = " nesne eklenemedi";
        public static string EntityUptaded = " Nesne güncellendi";
        public static string EntityNotFound = " Böyle bir obje yok";

        public static string EntityDeleted = " Nesne silindi";
        public static string ImageOfCarLimit="bir araç yalnız 5 tane resim alabilir";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="kullanıcı kayıt oldu";
        public static string UserNotFound="kulalnıcı bulunamadı";
        public static string PasswordError="kullanıcı şifre yanlış";
        public static string SuccessfulLogin="başarılı giriş";
       public static string UserAlreadyExists="kulllancıı zaten mevcut";
        public static string AccessTokenCreated="token başarılı yaratıldı";
    }
}
