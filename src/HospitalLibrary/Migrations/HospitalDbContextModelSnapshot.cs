﻿// <auto-generated />
using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Enums;
using HospitalLibrary.Core.Report.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    partial class HospitalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("HospitalLibrary.Core.Appointment.Appointment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("DoctorId")
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("PatientId")
                        .HasColumnType("text");

                    b.Property<int?>("PatientId1")
                        .HasColumnType("integer");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp without time zone");

                    b.Property<AppointmentStatus>("Status")
                        .HasColumnType("appointment_status");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId1");

                    b.HasIndex("RoomId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Blood.BloodConsumptionRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DoctorId")
                        .HasColumnType("text");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<Guid>("SourceBank")
                        .HasColumnType("uuid");

                    b.Property<BloodType>("Type")
                        .HasColumnType("blood_type");

                    b.HasKey("Id");

                    b.ToTable("BloodConsumptionRecords");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Blood.BloodRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DoctorId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Due")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BloodRequests");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Blood.BloodSupply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<Guid>("SourceBank")
                        .HasColumnType("uuid");

                    b.Property<BloodType>("Type")
                        .HasColumnType("blood_type");

                    b.HasKey("Id");

                    b.ToTable("HospitalBlood");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Consiliums.Consilium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("DoctorIds")
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<bool>("Finished")
                        .HasColumnType("boolean");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<string>("Specialties")
                        .HasColumnType("text");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Topic")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Consiliums");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Consiliums.ConsiliumAppointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ConsiliumId")
                        .HasColumnType("integer");

                    b.Property<string>("DoctorId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ConsiliumId");

                    b.HasIndex("DoctorId");

                    b.ToTable("ConsiliumAppointments");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Doctor.Doctor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("EndWorkTime")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<Specialty>("Specialty")
                        .HasColumnType("specialty");

                    b.Property<int>("StartWorkTime")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Feedback.Feedback", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Anonymous")
                        .HasColumnType("boolean");

                    b.Property<bool>("Approved")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PatientName")
                        .HasColumnType("text");

                    b.Property<string>("PatientSurname")
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<bool>("VisibleToPublic")
                        .HasColumnType("boolean");

                    b.HasKey("ID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Infrastructure.DomainEvent", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ReportId")
                        .HasColumnType("text");

                    b.Property<string>("event_type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.ToTable("ReportCreationEvents");

                    b.HasDiscriminator<string>("event_type").HasValue("DomainEvent");
                });

            modelBuilder.Entity("HospitalLibrary.Core.InpatientTreatmentRecord.Equipment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("HospitalLibrary.Core.InpatientTreatmentRecord.InpatientTreatmentRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("AdmissionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("AdmissionReason")
                        .HasColumnType("text");

                    b.Property<string>("BedID")
                        .HasColumnType("text");

                    b.Property<DateTime>("DischargeDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DischargeReason")
                        .HasColumnType("text");

                    b.Property<string>("DoctorID")
                        .HasColumnType("text");

                    b.Property<string>("PatientID")
                        .HasColumnType("text");

                    b.Property<string>("RoomID")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<string>("Therapy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("InpatientTreatmentRecords");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Patient.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<List<string>>("Allergies")
                        .HasColumnType("text[]");

                    b.Property<BloodType>("BloodType")
                        .HasColumnType("blood_type");

                    b.Property<string>("DoctorID")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<Gender>("Gender")
                        .HasColumnType("gender");

                    b.Property<string>("Jmbg")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Report.Model.DrugList", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DrugsList");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Report.Model.DrugPrescription", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<ICollection<Drug>>("Drugs")
                        .HasColumnType("jsonb");

                    b.Property<string>("ReportId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DrugPrescriptions");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Report.Model.Report", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("AppointmentId")
                        .HasColumnType("text");

                    b.Property<int>("CurrentStep")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DayAndTimeOfMaking")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DoctorId")
                        .HasColumnType("text");

                    b.Property<int>("InitialVersion")
                        .HasColumnType("integer");

                    b.Property<string>("PatientId")
                        .HasColumnType("text");

                    b.Property<string>("ReportDescription")
                        .HasColumnType("text");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Report.Model.SymptomList", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SymptomList");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Room.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HospitalLibrary.Core.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("IdByRole")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Vacation.VacationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("DoctorId")
                        .HasColumnType("text");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RejectionReason")
                        .HasColumnType("text");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<bool>("Urgency")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("VacationRequests");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Report.Model.BackButtonClicked", b =>
                {
                    b.HasBaseType("HospitalLibrary.Core.Infrastructure.DomainEvent");

                    b.Property<DateTime>("ClickedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("FromStep")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("back");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Report.Model.NextButtonClicked", b =>
                {
                    b.HasBaseType("HospitalLibrary.Core.Infrastructure.DomainEvent");

                    b.Property<DateTime>("ClickedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("NextButtonClicked_ClickedAt");

                    b.Property<int>("FromStep")
                        .HasColumnType("integer")
                        .HasColumnName("NextButtonClicked_FromStep");

                    b.HasDiscriminator().HasValue("next");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Report.Model.ReportCreated", b =>
                {
                    b.HasBaseType("HospitalLibrary.Core.Infrastructure.DomainEvent");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasDiscriminator().HasValue("created");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Report.Model.ReportFinished", b =>
                {
                    b.HasBaseType("HospitalLibrary.Core.Infrastructure.DomainEvent");

                    b.Property<DateTime>("FinishedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasDiscriminator().HasValue("finished");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Appointment.Appointment", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Doctor.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId");

                    b.HasOne("HospitalLibrary.Core.Patient.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId1");

                    b.HasOne("HospitalLibrary.Core.Room.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Blood.BloodRequest", b =>
                {
                    b.OwnsOne("HospitalLibrary.Core.Blood.Blood", "Blood", b1 =>
                        {
                            b1.Property<int>("BloodRequestId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<double>("Amount")
                                .HasColumnType("double precision");

                            b1.Property<BloodType>("Type")
                                .HasColumnType("blood_type");

                            b1.HasKey("BloodRequestId");

                            b1.ToTable("BloodRequests");

                            b1.WithOwner()
                                .HasForeignKey("BloodRequestId");
                        });

                    b.Navigation("Blood");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Consiliums.ConsiliumAppointment", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Consiliums.Consilium", "Consilium")
                        .WithMany("ConsiliumAppointments")
                        .HasForeignKey("ConsiliumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalLibrary.Core.Doctor.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.Navigation("Consilium");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Doctor.Doctor", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Room.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Infrastructure.DomainEvent", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Report.Model.Report", null)
                        .WithMany("Changes")
                        .HasForeignKey("ReportId");
                });

            modelBuilder.Entity("HospitalLibrary.Core.InpatientTreatmentRecord.Equipment", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Room.Room", null)
                        .WithMany("Equipment")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalLibrary.Core.Report.Model.Report", b =>
                {
                    b.OwnsMany("HospitalLibrary.Core.Report.Model.Drug", "Drugs", b1 =>
                        {
                            b1.Property<string>("ReportId")
                                .HasColumnType("text");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<string>("CompanyName")
                                .HasColumnType("text");

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.HasKey("ReportId", "Id");

                            b1.ToTable("Drugs");

                            b1.WithOwner()
                                .HasForeignKey("ReportId");
                        });

                    b.OwnsMany("HospitalLibrary.Core.Report.Model.Symptom", "Symptoms", b1 =>
                        {
                            b1.Property<string>("ReportId")
                                .HasColumnType("text");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.HasKey("ReportId", "Id");

                            b1.ToTable("Symptoms");

                            b1.WithOwner()
                                .HasForeignKey("ReportId");
                        });

                    b.Navigation("Drugs");

                    b.Navigation("Symptoms");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Vacation.VacationRequest", b =>
                {
                    b.HasOne("HospitalLibrary.Core.Doctor.Doctor", "Doctor")
                        .WithMany("VacationRequests")
                        .HasForeignKey("DoctorId");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Consiliums.Consilium", b =>
                {
                    b.Navigation("ConsiliumAppointments");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Doctor.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("VacationRequests");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Report.Model.Report", b =>
                {
                    b.Navigation("Changes");
                });

            modelBuilder.Entity("HospitalLibrary.Core.Room.Room", b =>
                {
                    b.Navigation("Equipment");
                });
#pragma warning restore 612, 618
        }
    }
}
