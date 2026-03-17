using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wypozyczalnia_Samochodow.Models;

namespace Wypozyczalnia_Samochodow.Models
{
    public class Klient
    {
        [Key]
        public int IdKlienta { get; set; }

        [Required]
        [MaxLength(50)]
        public string Imie { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nazwisko { get; set; }

        [Required]
        [Phone]
        [MaxLength(15)]
        public string Telefon { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string NrPrawaJazdy { get; set; }

        public ICollection<Wypozyczenie> Wypozyczenia { get; set; } = new List<Wypozyczenie>();
    }
}