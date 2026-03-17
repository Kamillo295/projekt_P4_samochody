using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wypozyczalnia_Samochodow.Models;

namespace Wypozyczalnia_Samochodow.Models
{
    public class Samochod
    {
        [Key]
        public int IdSamochodu { get; set; }

        [Required]
        [MaxLength(50)]
        public string Marka { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        public int Rok { get; set; }

        [Required]
        [MaxLength(15)]
        public string Rejestracja { get; set; }

        [Required]
        public decimal CenaZaDzien { get; set; }

        public bool Dostepny { get; set; }

        public ICollection<Wypozyczenie> Wypozyczenia { get; set; } = new List<Wypozyczenie>();
    }
}