using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_Samochowow.Models
{
    public class Wypozyczenie
    {
        public int Id { get; set; }
        public DateTime DataWypozyczenia { get; set; }
        public DateTime DataZwrotu { get; set; }
        public double CenaCalkowita { get; set; }
        public int SamochodId { get; set; }
        public Samochod Samochod { get; set; }
        public int KlientId { get; set; }
        public Klient Klient { get; set; }
        public Platnosc Platnosc { get; set; }
    }
}
