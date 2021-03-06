﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChinookCore.Data
{
    public partial class ChinookContext : DbContext
    {
        public ChinookContext()
        {
        }

        public ChinookContext(DbContextOptions<ChinookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistTrack> PlaylistTracks { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasIndex(e => e.ArtistId)
                    .HasName("IFK_AlbumArtistId");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK_AlbumArtistId");
            });

            modelBuilder.Entity<PlaylistTrack>(entity =>
            {
                entity.HasKey(e => new { e.PlaylistId, e.TrackId })
                    .IsClustered(false);

                entity.HasIndex(e => e.TrackId)
                    .HasName("IFK_PlaylistTrackTrackId");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PlaylistTracks)
                    .HasForeignKey(d => d.PlaylistId)
                    .HasConstraintName("FK_PlaylistTrackPlaylistId");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.PlaylistTracks)
                    .HasForeignKey(d => d.TrackId)
                    .HasConstraintName("FK_PlaylistTrackTrackId");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasIndex(e => e.AlbumId)
                    .HasName("IFK_TrackAlbumId");

                entity.Property(e => e.BinaryCol)
                    .IsFixedLength()
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BinaryColNull).IsFixedLength();

                entity.Property(e => e.CharCol)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CharColNull)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DateCol).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateTimeCol).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GuidCol).HasDefaultValueSql("(newid())");

                entity.Property(e => e.NcharCol)
                    .IsFixedLength()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NcharColNull).IsFixedLength();

                entity.Property(e => e.NvarCharCol).HasDefaultValueSql("('')");

                entity.Property(e => e.NvarCharColNull).HasDefaultValueSql("('')");

                entity.Property(e => e.SmallDateTimeCol).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TimeCol).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TimeStampCol)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.VarBinaryCol).HasDefaultValueSql("((0))");

                entity.Property(e => e.VarCharCol)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VarCharColNull).IsUnicode(false);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrackAlbumId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            // 연결문자열 설정
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Chinook;Integrated Security=True");
        }
    }
}