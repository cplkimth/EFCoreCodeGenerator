﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Chinook.Data
{
    public partial class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }
        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}