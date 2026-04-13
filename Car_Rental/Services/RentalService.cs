using Car_Rental.Data;
using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Services
{
    public class RentalService : IRentalService
    {
        public void AddRental(Rental rental)
        {
            using(var context = new CarRentalContext())
            {
                context.Add(rental);

                var autoDoWynajęcia = context.Cars.FirstOrDefault(c =>  c.Id == rental.Id);
                if(autoDoWynajęcia != null)
                {
                    autoDoWynajęcia.IsAvailable = false;
                    context.Cars.Update(autoDoWynajęcia);
                }
                context.SaveChanges();
            }
        }

        public List<Rental> GetAllRentals()
        {
            using (var context = new CarRentalContext())
            {
                return context.Rentals.ToList();
            }
        }

        public void DeleteRental(Rental rental)
        {
            using (var context = new CarRentalContext())
            {
                context.Rentals.Remove(rental);

                var autoDoZwrotu = context.Cars.FirstOrDefault(c => c.Id == rental.CarId);
                if( autoDoZwrotu != null )
                {
                    autoDoZwrotu.IsAvailable = true;
                    context.Cars.Update(autoDoZwrotu);
                }
                context.SaveChanges();
            }
        }
    }
}
