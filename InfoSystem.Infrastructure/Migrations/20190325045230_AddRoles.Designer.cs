﻿// <auto-generated />
using InfoSystem.Infrastructure.DataBase.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InfoSystem.Infrastructure.Migrations
{
    [DbContext(typeof(InfoSystemDbContext))]
    [Migration("20190325045230_AddRoles")]
    partial class AddRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("InfoSystem.Core.Entities.Basic.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("InfoSystem.Core.Entities.Basic.EntityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("InfoSystem.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanRead");

                    b.Property<bool>("CanWrite");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
