﻿namespace kuruinsaat.Migrations
{
    using kuruinsaat.Entity;
    using kuruinsaat.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<kuruinsaat.Entity.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(kuruinsaat.Entity.DataContext context)
        {

            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + "Kullanicilar" + "]");
            //context.SaveChanges();
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + "Roller" + "]");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + "ElementTypes" + "]");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + "Projeler" + "]");
            //context.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + "Resimler" + "]");
            //context.SaveChanges();

            //var kullaniciRolu = new List<Rol>()
            //{
            //    new Rol(){RolAdi="Admin", Gecerlimi = true},
            //    new Rol(){RolAdi = "User", Gecerlimi = true}
            //};
            //foreach (var item in kullaniciRolu)
            //{
            //    context.Roller.Add(item);
            //}
            //context.SaveChanges();



            //var kullanicilar = new List<Kullanici>()
            //         {
            //             new Kullanici(){Adi = "Admin Adı", Soyadi="Soyadi", Cinsiyet = true, Gecerlimi = true, KullaniciAdi="admin", RolId=1, Parola="123456",ReParola="123456", MailAdres="asdf"},
            //             new Kullanici(){Adi = "user adı", Soyadi="Soyadi", Cinsiyet = true, Gecerlimi = true, KullaniciAdi="user", RolId=2, Parola="123456",ReParola="123456", MailAdres="asdf"}
            //         };
            //foreach (var ekle in kullanicilar)
            //{
            //    context.Kullanicilar.Add(ekle);
            //}
            //context.SaveChanges();



            ////ELEMENTTYPES
            //var elementTypes = new List<ElementType>()
            //{
            //    new ElementType(){Adi = "PROJELER",Aktif=1,Id=1},
            //    new ElementType(){Adi = "KULLANICILAR",Aktif=1,Id=2}
            //};
            //foreach (var item in elementTypes)
            //{
            //    context.ElementTypes.Add(item);
            //}
            //context.SaveChanges();


            ////PROJECTS
            //var projects = new List<Proje>()
            //{
                
            //    new Proje(){Adi="Site",Aktif=1},
            //    new Proje(){Adi="Vadi",Aktif=1},
            //    new Proje(){Adi="Dora",Aktif=1},
            //    new Proje(){Adi="Apt",Aktif=1}


            //};

            //foreach (var item in projects)
            //{
            //    context.Projeler.Add(item);
            //}
            //context.SaveChanges();



            ////PROJEPİCTURES
            //ElementType elementTypeProjeler = elementTypes.Where(a => a.Adi == "PROJELER").FirstOrDefault();
            //var resimler = new List<Resim>()
            //{
                
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Site").First().Id, ResimYolu="selen-evler-site[1].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Site").First().Id, ResimYolu="selen-evler-site[2].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Site").First().Id, ResimYolu="selen-evler-site[3].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Site").First().Id, ResimYolu="selen-evler-site[4].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Site").First().Id, ResimYolu="selen-evler-site[5].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Site").First().Id, ResimYolu="selen-evler-site[6].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Site").First().Id, ResimYolu="selen-evler-site[7].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Site").First().Id, ResimYolu="selen-evler-site[8].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Site").First().Id, ResimYolu="selen-evler-site[9].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Site").First().Id, ResimYolu="selen-evler-site[10].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Vadi").First().Id, ResimYolu="selen-evler-vadi.jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId =  projects.Where(x=>x.Adi=="Vadi").First().Id, ResimYolu="selen-evler-vadi[1].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId =  projects.Where(x=>x.Adi=="Dora").First().Id, ResimYolu="selen-evler-dora.jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Dora").First().Id, ResimYolu="selen-evler-dora[1].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Dora").First().Id, ResimYolu="selen-evler-dora[2].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Dora").First().Id, ResimYolu="selen-evler-dora[3].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Dora").First().Id, ResimYolu="selen-evler-dora[4].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Dora").First().Id, ResimYolu="selen-evler-dora[5].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Dora").First().Id, ResimYolu="selen-evler-dora[6].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Dora").First().Id, ResimYolu="selen-evler-dora[7].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Dora").First().Id, ResimYolu="selen-evler-dora[8].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Dora").First().Id, ResimYolu="selen-evler-dora[9].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Dora").First().Id, ResimYolu="selen-evler-dora[10].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Apt").First().Id, ResimYolu="selen-evler-apartmani.jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Apt").First().Id, ResimYolu="selen-evler-apartmani[1].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Apt").First().Id, ResimYolu="selen-evler-apartmani[2].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Apt").First().Id, ResimYolu="selen-evler-apartmani[3].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Apt").First().Id, ResimYolu="selen-evler-apartmani[4].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Apt").First().Id, ResimYolu="selen-evler-apartmani[5].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Apt").First().Id, ResimYolu="selen-evler-apartmani[6].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Apt").First().Id, ResimYolu="selen-evler-apartmani[7].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Apt").First().Id, ResimYolu="selen-evler-apartmani[8].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Apt").First().Id, ResimYolu="selen-evler-apartmani[9].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Apt").First().Id, ResimYolu="selen-evler-apartmani[10].jpg",Aktif=1},
            //    new Resim(){EklemeZamani=DateTime.Now,Guncellemezamani=DateTime.Now, ElementTypeId = projects.Where(x=>x.Adi=="Apt").First().Id, ResimYolu="selen-evler-apartmani[11].jpg",Aktif=1},
            //};

            //foreach (var ekle in resimler)
            //{
            //    context.Resimler.Add(ekle);
            //}
            //context.SaveChanges();






            //base.Seed(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //enable-migration
            //update-database
            //update-database -verbose
        }

    }
}
