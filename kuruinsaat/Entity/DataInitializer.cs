﻿using kuruinsaat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace kuruinsaat.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        //private DataContext db = new DataContext();
        //public  DataInitializer() {
        //    Seed(db);
        //}

        protected override void Seed(DataContext context)
        {

            var kullaniciRolu = new List<Rol>()
            {
                new Rol(){RolAdi="Admin", Gecerlimi = true},
                new Rol(){RolAdi = "User", Gecerlimi = true}
            };
            foreach (var item in kullaniciRolu)
            {
                context.Roller.Add(item);
            }
            context.SaveChanges();



            var kullanicilar = new List<Kullanici>()
                     {
                         new Kullanici(){Adi = "Admin Adı", Soyadi="Soyadi", Cinsiyet = true, Gecerlimi = true, KullaniciAdi="admin", RolId=1, Parola="123456",ReParola="123456", MailAdres="asdf"},
                         new Kullanici(){Adi = "user adı", Soyadi="Soyadi", Cinsiyet = true, Gecerlimi = true, KullaniciAdi="user", RolId=2, Parola="123456",ReParola="123456", MailAdres="asdf"}
                     };
            foreach (var ekle in kullanicilar)
            {
                context.Kullanicilar.Add(ekle);
            }
            context.SaveChanges();



            //ELEMENTTYPES
            var elementTypes = new List<ElementType>()
            {
                new ElementType(){Adi = "PROJELER",Aktif=1,Id=1},
                new ElementType(){Adi = "KULLANICILAR",Aktif=1,Id=2}
            };
            foreach (var item in elementTypes)
            {
                context.ElementTypes.Add(item);
            }
            context.SaveChanges();


            //PROJECTS
            var projects = new List<Proje>()
            {
                new Proje(){Id=1,Adi="Site",Aktif=1},
                new Proje(){Id=2,Adi="Vadi",Aktif=1},
                new Proje(){Id=3,Adi="Dora",Aktif=1},
                new Proje(){Id=4,Adi="Apt",Aktif=1}
            };




            //PROJEPİCTURES
            ElementType elementTypeProjeler = elementTypes.Where(a => a.Adi == "PROJELER").FirstOrDefault();
            var resimler = new List<Resim>()
            {
                new Resim(){Id = 1, ElementTypeId = 1, ResimYolu="selen-evler-site[1].jpg",Aktif=1},
                new Resim(){Id = 2, ElementTypeId = 1, ResimYolu="selen-evler-site[2].jpg",Aktif=1},
                new Resim(){Id = 3, ElementTypeId = 1, ResimYolu="selen-evler-site[3].jpg",Aktif=1},
                new Resim(){Id = 4, ElementTypeId = 1, ResimYolu="selen-evler-site[4].jpg",Aktif=1},
                new Resim(){Id = 5, ElementTypeId = 1, ResimYolu="selen-evler-site[5].jpg",Aktif=1},
                new Resim(){Id = 6, ElementTypeId = 1, ResimYolu="selen-evler-site[6].jpg",Aktif=1},
                new Resim(){Id = 7, ElementTypeId = 1, ResimYolu="selen-evler-site[7].jpg",Aktif=1},
                new Resim(){Id = 8, ElementTypeId = 1, ResimYolu="selen-evler-site[8].jpg",Aktif=1},
                new Resim(){Id = 9, ElementTypeId = 1, ResimYolu="selen-evler-site[9].jpg",Aktif=1},
                new Resim(){Id = 10, ElementTypeId = 1, ResimYolu="selen-evler-site[10].jpg",Aktif=1},
                new Resim(){Id = 11, ElementTypeId = 2, ResimYolu="selen-evler-vadi.jpg",Aktif=1},
                new Resim(){Id = 12, ElementTypeId = 2, ResimYolu="selen-evler-vadi[1].jpg",Aktif=1},
                new Resim(){Id = 13, ElementTypeId = 3, ResimYolu="selen-evler-dora.jpg",Aktif=1},
                new Resim(){Id = 14, ElementTypeId = 3, ResimYolu="selen-evler-dora[1].jpg",Aktif=1},
                new Resim(){Id = 15, ElementTypeId = 3, ResimYolu="selen-evler-dora[2].jpg",Aktif=1},
                new Resim(){Id = 16, ElementTypeId = 3, ResimYolu="selen-evler-dora[3].jpg",Aktif=1},
                new Resim(){Id = 17, ElementTypeId = 3, ResimYolu="selen-evler-dora[4].jpg",Aktif=1},
                new Resim(){Id = 18, ElementTypeId = 3, ResimYolu="selen-evler-dora[5].jpg",Aktif=1},
                new Resim(){Id = 19, ElementTypeId = 3, ResimYolu="selen-evler-dora[6].jpg",Aktif=1},
                new Resim(){Id = 20, ElementTypeId = 3, ResimYolu="selen-evler-dora[7].jpg",Aktif=1},
                new Resim(){Id = 21, ElementTypeId = 3, ResimYolu="selen-evler-dora[8].jpg",Aktif=1},
                new Resim(){Id = 22, ElementTypeId = 3, ResimYolu="selen-evler-dora[9].jpg",Aktif=1},
                new Resim(){Id = 23, ElementTypeId = 3, ResimYolu="selen-evler-dora[10].jpg",Aktif=1},
                new Resim(){Id = 24, ElementTypeId = 4, ResimYolu="selen-evler-apartmani.jpg",Aktif=1},
                new Resim(){Id = 25, ElementTypeId = 4, ResimYolu="selen-evler-apartmani[1].jpg",Aktif=1},
                new Resim(){Id = 26, ElementTypeId = 4, ResimYolu="selen-evler-apartmani[2].jpg",Aktif=1},
                new Resim(){Id = 27, ElementTypeId = 4, ResimYolu="selen-evler-apartmani[3].jpg",Aktif=1},
                new Resim(){Id = 28, ElementTypeId = 4, ResimYolu="selen-evler-apartmani[4].jpg",Aktif=1},
                new Resim(){Id = 29, ElementTypeId = 4, ResimYolu="selen-evler-apartmani[5].jpg",Aktif=1},
                new Resim(){Id = 30, ElementTypeId = 4, ResimYolu="selen-evler-apartmani[6].jpg",Aktif=1},
                new Resim(){Id = 31, ElementTypeId = 4, ResimYolu="selen-evler-apartmani[7].jpg",Aktif=1},
                new Resim(){Id = 32, ElementTypeId = 4, ResimYolu="selen-evler-apartmani[8].jpg",Aktif=1},
                new Resim(){Id = 33, ElementTypeId = 4, ResimYolu="selen-evler-apartmani[9].jpg",Aktif=1},
                new Resim(){Id = 34, ElementTypeId = 4, ResimYolu="selen-evler-apartmani[10].jpg",Aktif=1},
                new Resim(){Id = 35, ElementTypeId = 4, ResimYolu="selen-evler-apartmani[11].jpg",Aktif=1},
            };






            base.Seed(context);
        }
    }
}