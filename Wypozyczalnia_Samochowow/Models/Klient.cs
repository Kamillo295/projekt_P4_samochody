using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia_Samochowow.Models
{
    public class Klient
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string NrPrawaJazdy { get; set; }
        public List<Wypozyczenie> Wypozyczenia { get; set; }
    }

}
