﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineSurveyApp.Infrastructure.Data;

#nullable disable

namespace OnlineSurveyApp.Infrastructure.Migrations
{
    [DbContext(typeof(OnlineSurveyDbContext))]
    partial class OnlineSurveyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineSurveyApp.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Evaluation")
                        .HasColumnType("int");

                    b.Property<int?>("OptionId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("RedditiveId")
                        .HasColumnType("int");

                    b.Property<int?>("SurveyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("RedditiveId");

                    b.HasIndex("SurveyId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("OnlineSurveyApp.Entities.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("OnlineSurveyApp.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ScoringRequirement")
                        .HasColumnType("bit");

                    b.Property<int?>("SurveyId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("OnlineSurveyApp.Entities.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("ConstituentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("ConstituentId");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("OnlineSurveyApp.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OnlineSurveyApp.Entities.Answer", b =>
                {
                    b.HasOne("OnlineSurveyApp.Entities.Option", "Option")
                        .WithMany("Answers")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OnlineSurveyApp.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OnlineSurveyApp.Entities.User", "Redditive")
                        .WithMany("Answers")
                        .HasForeignKey("RedditiveId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OnlineSurveyApp.Entities.Survey", "Survey")
                        .WithMany("Answers")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Option");

                    b.Navigation("Question");

                    b.Navigation("Redditive");

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("OnlineSurveyApp.Entities.Option", b =>
                {
                    b.HasOne("OnlineSurveyApp.Entities.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Question");
                });

            modelBuilder.Entity("OnlineSurveyApp.Entities.Question", b =>
                {
                    b.HasOne("OnlineSurveyApp.Entities.Survey", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("OnlineSurveyApp.Entities.Survey", b =>
                {
                    b.HasOne("OnlineSurveyApp.Entities.User", "Constituent")
                        .WithMany("Surveys")
                        .HasForeignKey("ConstituentId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Constituent");
                });

            modelBuilder.Entity("OnlineSurveyApp.Entities.Option", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("OnlineSurveyApp.Entities.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Options");
                });

            modelBuilder.Entity("OnlineSurveyApp.Entities.Survey", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("OnlineSurveyApp.Entities.User", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Surveys");
                });
#pragma warning restore 612, 618
        }
    }
}
