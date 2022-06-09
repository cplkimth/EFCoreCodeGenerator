﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChinookCore.Data
{
    [Table("Genre")]
    public partial class Genre
    {
        public Genre()
        {
            Tracks = new HashSet<Track>();
        }

        [Key]
        public int GenreId { get; set; }
        [StringLength(120)]
        public string Name { get; set; }

        [InverseProperty("Genre")]
        public virtual ICollection<Track> Tracks { get; set; }
    }
}