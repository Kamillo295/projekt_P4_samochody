using Microsoft.EntityFrameworkCore;
using Wypozyczalnia_Samochodow.Models;

namespace Wypozyczalnia_Samochodow.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Samochod> Samochody { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Wypozyczenie> Wypozyczenia { get; set; }
        public DbSet<Platnosc> Platnosci { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=WypozyczalniaDB;Integrated Security=True");
        }
    }
}