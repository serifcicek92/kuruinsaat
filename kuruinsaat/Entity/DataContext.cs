using kuruinsaat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace kuruinsaat.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("KuruInsaatDatabase")
        {
            //Database.SetInitializer<DataContext>(new DropCreateDatabaseIfModelChanges<DataContext>()); //model değiştiğinde yenien oluştur
            //Database.Initialize(true);
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Proje> Projeler { get; set; }
        public DbSet<Resim> Resimler { get; set; }
        public DbSet<ElementType> ElementTypes { get; set; }
        public DbSet<Dosya> Dosyalar { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<DataContext>(new DropCreateDatabaseAlways<DataContext>());
            Database.SetInitializer<DataContext>(new DropCreateDatabaseAlways<DataContext>());
            //base.OnModelCreating(modelBuilder);
        }
    }
}