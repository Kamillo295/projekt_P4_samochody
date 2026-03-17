using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wypozyczalnia_Samochodow.Models;

namespace Wypozyczalnia_Samochodow.Models
{
    public class Wypozyczenie
    {
        [Key]
        public int IdWypozyczenia { get; set; }

        [Required]
        public DateTime DataWypozyczenia { get; set; }

        [Required]
        public DateTime DataZwrotu { get; set; }

        [Required]
        public decimal CenaCalkowita { get; set; }

        [Required]
        [ForeignKey(nameof(Samochod))]
        public int SamochodId { get; set; }
        public Samochod Samochod { get; set; }

        [Required]
        [ForeignKey(nameof(Klient))]
        public int KlientId { get; set; }
        public Klient Klient { get; set; }
        public Platnosc Platnosc { get; set; }
    }
}