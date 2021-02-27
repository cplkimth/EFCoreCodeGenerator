﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChinookCore.Data
{
    [Table("PlaylistTrack")]
    public partial class PlaylistTrack
    {
        [Key]
        public int PlaylistId { get; set; }
        [Key]
        public int TrackId { get; set; }
        public bool? Dummy { get; set; }

        [ForeignKey(nameof(PlaylistId))]
        [InverseProperty("PlaylistTracks")]
        public virtual Playlist Playlist { get; set; }
        [ForeignKey(nameof(TrackId))]
        [InverseProperty("PlaylistTracks")]
        public virtual Track Track { get; set; }
    }
}