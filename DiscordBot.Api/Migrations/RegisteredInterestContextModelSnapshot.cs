﻿// <auto-generated />
using System;
using DiscordBot.Api.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DiscordBot.Api.Migrations
{
    [DbContext(typeof(RegisteredInterestContext))]
    partial class RegisteredInterestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DiscordBot.Api.Models.Database.RegisteredInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("TimeRegistered")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("InterestRegistrations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TimeRegistered = new DateTime(2024, 7, 16, 10, 53, 8, 73, DateTimeKind.Utc).AddTicks(1660)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
