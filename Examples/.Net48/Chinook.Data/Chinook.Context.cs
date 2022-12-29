﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chinook.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ChinookEntities : DbContext
    {
        public ChinookEntities()
            : base("name=ChinookEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistTrack> PlaylistTracks { get; set; }
        public virtual DbSet<PlaylistTrackHistory> PlaylistTrackHistories { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<AlbumView> AlbumViews { get; set; }
    
        public virtual ObjectResult<Album_Search_Result> Album_Search(Nullable<int> artistId, string title)
        {
            var artistIdParameter = artistId.HasValue ?
                new ObjectParameter("ArtistId", artistId) :
                new ObjectParameter("ArtistId", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Album_Search_Result>("Album_Search", artistIdParameter, titleParameter);
        }
    
        public virtual int Initialize()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Initialize");
        }
    
        public virtual ObjectResult<Track_Search_Result> Track_Search(string name, Nullable<int> artistId)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var artistIdParameter = artistId.HasValue ?
                new ObjectParameter("ArtistId", artistId) :
                new ObjectParameter("ArtistId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Track_Search_Result>("Track_Search", nameParameter, artistIdParameter);
        }
    }
}