﻿// <auto-generated />
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("API.Models.Aluno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("API.Models.IMC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Altura")
                        .HasColumnType("REAL");

                    b.Property<int?>("Alunoid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Classificacao")
                        .HasColumnType("TEXT");

                    b.Property<double>("Peso")
                        .HasColumnType("REAL");

                    b.Property<double>("ValorIMC")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Alunoid");

                    b.ToTable("IMC");
                });

            modelBuilder.Entity("API.Models.IMC", b =>
                {
                    b.HasOne("API.Models.Aluno", "Aluno")
                        .WithMany("IMC")
                        .HasForeignKey("Alunoid");

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("API.Models.Aluno", b =>
                {
                    b.Navigation("IMC");
                });
#pragma warning restore 612, 618
        }
    }
}
