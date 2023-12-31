﻿// <auto-generated />
using Enitiy_framework_with_Swagger_API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Enitiy_framework_with_Swagger_API.Migrations
{
    [DbContext(typeof(CRUDContext))]
    [Migration("20231231103901_firstmigration")]
    partial class firstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Enitiy_framework_with_Swagger_API.Models.Student", b =>
                {
                    b.Property<int>("studentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("studentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentRoll")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("studentID");

                    b.ToTable("students");
                });
#pragma warning restore 612, 618
        }
    }
}
