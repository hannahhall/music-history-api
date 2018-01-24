﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MusicHistoryApi.Data;
using System;

namespace MusicHistoryApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180124153849_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("MusicHistoryApi.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("AlbumId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("MusicHistoryApi.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistName")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<int>("YearEstablished");

                    b.HasKey("ArtistId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("MusicHistoryApi.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("GenreId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MusicHistoryApi.Models.Song", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlbumId");

                    b.Property<int>("ArtistId");

                    b.Property<int>("GenreId");

                    b.Property<DateTime>("ReleaseDate")
                        .HasMaxLength(55);

                    b.Property<int>("SongLength")
                        .HasMaxLength(55);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("SongId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("MusicHistoryApi.Models.Song", b =>
                {
                    b.HasOne("MusicHistoryApi.Models.Album", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MusicHistoryApi.Models.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MusicHistoryApi.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}