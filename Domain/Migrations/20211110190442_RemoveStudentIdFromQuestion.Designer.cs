﻿// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Domain.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211110190442_RemoveStudentIdFromQuestion")]
    partial class RemoveStudentIdFromQuestion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Domain.Models.Student.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<long>("Number")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Domain.Models.Student.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("TEXT");

                    b.Property<long>("GroupNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Domain.Models.Survey.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OptionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("TEXT");

                    b.Property<long>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SurveyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Domain.Models.Survey.Option", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Domain.Models.Survey.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SurveyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Domain.Models.Survey.QuestionMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("MessageId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("TEXT");

                    b.Property<long>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionMessage");
                });

            modelBuilder.Entity("Domain.Models.Survey.Survey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<long>("GroupNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("Domain.Models.Student.Student", b =>
                {
                    b.HasOne("Domain.Models.Student.Group", null)
                        .WithMany("Students")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Domain.Models.Survey.Answer", b =>
                {
                    b.HasOne("Domain.Models.Survey.Option", "Option")
                        .WithMany()
                        .HasForeignKey("OptionId");

                    b.Navigation("Option");
                });

            modelBuilder.Entity("Domain.Models.Survey.Option", b =>
                {
                    b.HasOne("Domain.Models.Survey.Question", null)
                        .WithMany("Options")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("Domain.Models.Survey.Question", b =>
                {
                    b.HasOne("Domain.Models.Survey.Survey", null)
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId");
                });

            modelBuilder.Entity("Domain.Models.Survey.QuestionMessage", b =>
                {
                    b.HasOne("Domain.Models.Survey.Question", null)
                        .WithMany("Messages")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("Domain.Models.Student.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Domain.Models.Survey.Question", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Options");
                });

            modelBuilder.Entity("Domain.Models.Survey.Survey", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
