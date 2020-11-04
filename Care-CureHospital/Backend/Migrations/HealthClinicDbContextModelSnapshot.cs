﻿// <auto-generated />
using System;
using Backend.Repository.MySQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(HealthClinicDbContext))]
    partial class HealthClinicDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.Model.BlogAndNotification.PatientFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForPublishing")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PatientFeedbacks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAnonymous = true,
                            IsForPublishing = true,
                            IsPublished = false,
                            PatientID = 1,
                            PublishingDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Text = "Text"
                        });
                });

            modelBuilder.Entity("Model.AllActors.City", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostCode")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("CountryID");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CountryID = 1,
                            Name = "Beograd",
                            PostCode = 11000
                        });
                });

            modelBuilder.Entity("Model.AllActors.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Code = "SRB",
                            Name = "Srbija"
                        });
                });

            modelBuilder.Entity("Model.AllActors.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GuestAccount")
                        .HasColumnType("bit");

                    b.Property<string>("Jmbg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedicalRecordID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cityID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContactNumber = "063555333",
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EMail = "pera@gmail.com",
                            GuestAccount = false,
                            Jmbg = "123",
                            MedicalRecordID = 1,
                            Name = "Petar",
                            Password = "123",
                            Surname = "Petrovic",
                            Username = "pera",
                            cityID = 1
                        });
                });

            modelBuilder.Entity("Model.DoctorMenager.Medicament", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredients")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MedicalRecordid")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Producer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StateOfValidation")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("MedicalRecordid");

                    b.ToTable("Medicaments");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Code = "c35",
                            Ingredients = "sastojak1, sastojak2, sastojak3",
                            Name = "Brufen",
                            Producer = "Hemofarm",
                            Quantity = 10,
                            StateOfValidation = 0
                        });
                });

            modelBuilder.Entity("Model.PatientDoctor.Allergies", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MedicalRecordid")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("MedicalRecordid");

                    b.ToTable("Allergiess");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Name = "penicilin"
                        });
                });

            modelBuilder.Entity("Model.PatientDoctor.Anamnesis", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Anamnesies");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Description = "pacijent je dobro"
                        });
                });

            modelBuilder.Entity("Model.PatientDoctor.Diagnosis", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Anamnesisid")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Anamnesisid");

                    b.ToTable("Diagnosies");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Name = "prehlada"
                        });
                });

            modelBuilder.Entity("Model.PatientDoctor.MedicalRecord", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("anamnesisID")
                        .HasColumnType("int");

                    b.Property<int>("patientID")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("anamnesisID");

                    b.ToTable("MedicalRecords");

                    b.HasData(
                        new
                        {
                            id = 1,
                            anamnesisID = 1,
                            patientID = 1
                        });
                });

            modelBuilder.Entity("Model.PatientDoctor.Symptoms", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Anamnesisid")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Anamnesisid");

                    b.ToTable("Symptomes");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Name = "temperatura"
                        },
                        new
                        {
                            id = 3,
                            Name = "kijanje"
                        });
                });

            modelBuilder.Entity("Model.AllActors.City", b =>
                {
                    b.HasOne("Model.AllActors.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.DoctorMenager.Medicament", b =>
                {
                    b.HasOne("Model.PatientDoctor.MedicalRecord", null)
                        .WithMany("Medicament")
                        .HasForeignKey("MedicalRecordid");
                });

            modelBuilder.Entity("Model.PatientDoctor.Allergies", b =>
                {
                    b.HasOne("Model.PatientDoctor.MedicalRecord", null)
                        .WithMany("Allergies")
                        .HasForeignKey("MedicalRecordid");
                });

            modelBuilder.Entity("Model.PatientDoctor.Diagnosis", b =>
                {
                    b.HasOne("Model.PatientDoctor.Anamnesis", null)
                        .WithMany("Diagnosis")
                        .HasForeignKey("Anamnesisid");
                });

            modelBuilder.Entity("Model.PatientDoctor.MedicalRecord", b =>
                {
                    b.HasOne("Model.PatientDoctor.Anamnesis", "Anamnesis")
                        .WithMany()
                        .HasForeignKey("anamnesisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.AllActors.Patient", "Patient")
                        .WithOne("MedicalRecord")
                        .HasForeignKey("Model.PatientDoctor.MedicalRecord", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.PatientDoctor.Symptoms", b =>
                {
                    b.HasOne("Model.PatientDoctor.Anamnesis", null)
                        .WithMany("Symptoms")
                        .HasForeignKey("Anamnesisid");
                });
#pragma warning restore 612, 618
        }
    }
}