﻿// <auto-generated />
using Clinic_Registration_and_Management.ApplicationDBclinicDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clinic_Registration_and_Management.Migrations
{
    [DbContext(typeof(ApplicationDBClining))]
    [Migration("20231220151215_a_medical_specialization")]
    partial class a_medical_specialization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);
#pragma warning restore 612, 618
        }
    }
}