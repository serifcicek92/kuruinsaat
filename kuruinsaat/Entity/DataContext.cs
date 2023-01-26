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
            //Database.SetInitializer<DataContext>(new CreateDatabaseIfNotExists<DataContext>());

            Database.SetInitializer<DataContext>(new DropCreateDatabaseIfModelChanges<DataContext>());
            //Database.SetInitializer<DataContext>(new DataInitializer());
            //Database.SetInitializer<DataContext>(new DropCreateDatabaseAlways<DataContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Proje> Projeler { get; set; }
        public DbSet<Resim> Resimler { get; set; }
        public DbSet<ElementType> ElementTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }
    }
}