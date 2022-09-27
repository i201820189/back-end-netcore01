﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using back_end;

namespace back_end.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("back_end.Entidades.Actor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("biografia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("id");

                    b.ToTable("Actores");
                });

            modelBuilder.Entity("back_end.Entidades.Cine", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<Point>("ubicacion")
                        .HasColumnType("geography");

                    b.HasKey("id");

                    b.ToTable("Cines");
                });

            modelBuilder.Entity("back_end.Entidades.Genero", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("back_end.Entidades.Pelicula", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("enCines")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fechaLanzamiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("poster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("resumen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("trailer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("back_end.Entidades.PeliculasActores", b =>
                {
                    b.Property<int>("actorID")
                        .HasColumnType("int");

                    b.Property<int>("peliculaID")
                        .HasColumnType("int");

                    b.Property<int>("orden")
                        .HasColumnType("int");

                    b.Property<string>("personaje")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("actorID", "peliculaID");

                    b.HasIndex("peliculaID");

                    b.ToTable("PeliculasActores");
                });

            modelBuilder.Entity("back_end.Entidades.PeliculasCines", b =>
                {
                    b.Property<int>("peliculaID")
                        .HasColumnType("int");

                    b.Property<int>("cineID")
                        .HasColumnType("int");

                    b.HasKey("peliculaID", "cineID");

                    b.HasIndex("cineID");

                    b.ToTable("PeliculasCines");
                });

            modelBuilder.Entity("back_end.Entidades.PeliculasGeneros", b =>
                {
                    b.Property<int>("peliculaID")
                        .HasColumnType("int");

                    b.Property<int>("generoID")
                        .HasColumnType("int");

                    b.HasKey("peliculaID", "generoID");

                    b.HasIndex("generoID");

                    b.ToTable("PeliculasGeneros");
                });

            modelBuilder.Entity("back_end.Entidades.PeliculasActores", b =>
                {
                    b.HasOne("back_end.Entidades.Actor", "actor")
                        .WithMany("peliculasActores")
                        .HasForeignKey("actorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back_end.Entidades.Pelicula", "pelicula")
                        .WithMany("peliculasActores")
                        .HasForeignKey("peliculaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("actor");

                    b.Navigation("pelicula");
                });

            modelBuilder.Entity("back_end.Entidades.PeliculasCines", b =>
                {
                    b.HasOne("back_end.Entidades.Cine", "cine")
                        .WithMany("peliculasCines")
                        .HasForeignKey("cineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back_end.Entidades.Pelicula", "pelicula")
                        .WithMany("peliculasCines")
                        .HasForeignKey("peliculaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cine");

                    b.Navigation("pelicula");
                });

            modelBuilder.Entity("back_end.Entidades.PeliculasGeneros", b =>
                {
                    b.HasOne("back_end.Entidades.Genero", "genero")
                        .WithMany("peliculasGeneros")
                        .HasForeignKey("generoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("back_end.Entidades.Pelicula", "pelicula")
                        .WithMany("peliculasGeneros")
                        .HasForeignKey("peliculaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("genero");

                    b.Navigation("pelicula");
                });

            modelBuilder.Entity("back_end.Entidades.Actor", b =>
                {
                    b.Navigation("peliculasActores");
                });

            modelBuilder.Entity("back_end.Entidades.Cine", b =>
                {
                    b.Navigation("peliculasCines");
                });

            modelBuilder.Entity("back_end.Entidades.Genero", b =>
                {
                    b.Navigation("peliculasGeneros");
                });

            modelBuilder.Entity("back_end.Entidades.Pelicula", b =>
                {
                    b.Navigation("peliculasActores");

                    b.Navigation("peliculasCines");

                    b.Navigation("peliculasGeneros");
                });
#pragma warning restore 612, 618
        }
    }
}
