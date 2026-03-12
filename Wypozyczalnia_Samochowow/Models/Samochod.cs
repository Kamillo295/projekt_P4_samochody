using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_Samochowow.Models
{
    public class Samochod
    {
        public int Id { get; set; }

        public string Marka { get; set; }
        public string Model { get; set; }
        public int Rok { get; set; }

        public string Rejestracja { get; set; }

        public double CenaZaDzien { get; set; }

        public bool Dostepny { get; set; }

        public List<Wypozyczenie> Wypozyczenia { get; set; }
    }
}
