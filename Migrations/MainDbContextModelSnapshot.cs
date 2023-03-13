﻿// <auto-generated />
using System;
using DsrCourseProjectTranslations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DsrCourseProjectTranslations.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DsrCourseProjectTranslations.Data.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("languages", (string)null);
                });

            modelBuilder.Entity("DsrCourseProjectTranslations.Data.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("Uid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.HasIndex("Value")
                        .IsUnique();

                    b.ToTable("tags", (string)null);
                });

            modelBuilder.Entity("DsrCourseProjectTranslations.Data.Entities.TranslationAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TranslationRequestId")
                        .HasColumnType("int");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TranslationRequestId");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("answers", (string)null);
                });

            modelBuilder.Entity("DsrCourseProjectTranslations.Data.Entities.TranslationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SourceLanguageId")
                        .HasColumnType("int");

                    b.Property<int>("TargetLanguageId")
                        .HasColumnType("int");

                    b.Property<Guid>("Uid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SourceLanguageId");

                    b.HasIndex("TargetLanguageId");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("translations", (string)null);
                });

            modelBuilder.Entity("TagTranslationRequest", b =>
                {
                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.Property<int>("TranslationsId")
                        .HasColumnType("int");

                    b.HasKey("TagsId", "TranslationsId");

                    b.HasIndex("TranslationsId");

                    b.ToTable("request_tags", (string)null);
                });

            modelBuilder.Entity("DsrCourseProjectTranslations.Data.Entities.TranslationAnswer", b =>
                {
                    b.HasOne("DsrCourseProjectTranslations.Data.Entities.TranslationRequest", "Request")
                        .WithMany("Answers")
                        .HasForeignKey("TranslationRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("DsrCourseProjectTranslations.Data.Entities.TranslationRequest", b =>
                {
                    b.HasOne("DsrCourseProjectTranslations.Data.Entities.Language", "SourceLanguage")
                        .WithMany("RequestsFromLanguage")
                        .HasForeignKey("SourceLanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DsrCourseProjectTranslations.Data.Entities.Language", "TargetLanguage")
                        .WithMany("RequestsToLanguage")
                        .HasForeignKey("TargetLanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SourceLanguage");

                    b.Navigation("TargetLanguage");
                });

            modelBuilder.Entity("TagTranslationRequest", b =>
                {
                    b.HasOne("DsrCourseProjectTranslations.Data.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DsrCourseProjectTranslations.Data.Entities.TranslationRequest", null)
                        .WithMany()
                        .HasForeignKey("TranslationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DsrCourseProjectTranslations.Data.Entities.Language", b =>
                {
                    b.Navigation("RequestsFromLanguage");

                    b.Navigation("RequestsToLanguage");
                });

            modelBuilder.Entity("DsrCourseProjectTranslations.Data.Entities.TranslationRequest", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
