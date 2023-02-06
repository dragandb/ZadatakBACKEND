﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ZadatakAPI.Models.DTO
{
    [Index(nameof(Sifra), IsUnique = true)]
    public class KupacDTO
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Sifra { get; set; }

        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(255)]
        public string Adresa { get; set; }

        [Required]
        [StringLength(255)]
        public string Mjesto { get; set; }
    }
}