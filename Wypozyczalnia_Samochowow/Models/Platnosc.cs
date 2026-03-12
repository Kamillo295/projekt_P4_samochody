using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_Samochowow.Models
{
    public class Platnosc
    {
        public int Id { get; set; }
        public double Kwota { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public int WypozyczenieId { get; set; }
        public Wypozyczenie Wypozyczenie { get; set; }
    }
}
