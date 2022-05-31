﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveyMakerApi.Persistence.Context;

#nullable disable

namespace SurveyMakerApi.Persistence.Migrations
{
    [DbContext(typeof(SurveyMakerContext))]
    [Migration("20220327011948_InitialData")]
    partial class InitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SurveyMakerApi.Persistence.Models.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("survey_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DisabledAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EndsAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Link")
                        .HasColumnType("char(36)");

                    b.Property<int>("SurveyStatusId")
                        .HasColumnType("int")
                        .HasColumnName("survey_status_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("SurveyStatusId");

                    b.HasIndex(new[] { "Id" }, "fk_survey_survey_statuses_idx");

                    b.HasIndex(new[] { "Id" }, "fk_survey_users_idx");

                    b.ToTable("surveys", (string)null);
                });

            modelBuilder.Entity("SurveyMakerApi.Persistence.Models.SurveyStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("status_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("statuses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Active"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Draft"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Completed"
                        });
                });

            modelBuilder.Entity("SurveyMakerApi.Persistence.Models.SurveyTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("tag_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("tags", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Basketball"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Education"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Politics"
                        });
                });

            modelBuilder.Entity("SurveyMakerApi.Persistence.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "test@test.com",
                            Password = "test"
                        });
                });

            modelBuilder.Entity("SurveySurveyTag", b =>
                {
                    b.Property<int>("SurveyTagsId")
                        .HasColumnType("int");

                    b.Property<int>("SurveysId")
                        .HasColumnType("int");

                    b.HasKey("SurveyTagsId", "SurveysId");

                    b.HasIndex("SurveysId");

                    b.ToTable("surveys_tags", (string)null);
                });

            modelBuilder.Entity("SurveyMakerApi.Persistence.Models.Survey", b =>
                {
                    b.HasOne("SurveyMakerApi.Persistence.Models.User", "User")
                        .WithMany("Surveys")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_surveys_users");

                    b.HasOne("SurveyMakerApi.Persistence.Models.SurveyStatus", "SurveyStatus")
                        .WithMany("Surveys")
                        .HasForeignKey("SurveyStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_survey_statuses");

                    b.Navigation("SurveyStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SurveySurveyTag", b =>
                {
                    b.HasOne("SurveyMakerApi.Persistence.Models.SurveyTag", null)
                        .WithMany()
                        .HasForeignKey("SurveyTagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SurveyMakerApi.Persistence.Models.Survey", null)
                        .WithMany()
                        .HasForeignKey("SurveysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SurveyMakerApi.Persistence.Models.SurveyStatus", b =>
                {
                    b.Navigation("Surveys");
                });

            modelBuilder.Entity("SurveyMakerApi.Persistence.Models.User", b =>
                {
                    b.Navigation("Surveys");
                });
#pragma warning restore 612, 618
        }
    }
}
