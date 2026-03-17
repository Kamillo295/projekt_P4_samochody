using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wypozyczalnia_Samochodow.Models
{
    public class Platnosc
    {
        [Key]
        public int IdPlatnosci { get; set; }

        [Required]
        public decimal Kwota { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        [Required]
        [ForeignKey(nameof(Wypozyczenie))]
        public int WypozyczenieId { get; set; }
        public Wypozyczenie Wypozyczenie { get; set; }
    }
}