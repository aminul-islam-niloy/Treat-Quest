﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TreatQuest.Data;

#nullable disable

namespace TreatQuest.Migrations
{
    [DbContext(typeof(QuizAppContext))]
    [Migration("20240808193419_inital")]
    partial class inital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TreatQuest.Models.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("TreatQuest.Models.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubChoiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubChoiceId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("TreatQuest.Models.SubChoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubOptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubOptionId");

                    b.ToTable("SubChoices");
                });

            modelBuilder.Entity("TreatQuest.Models.SubOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.ToTable("SubOptions");
                });

            modelBuilder.Entity("TreatQuest.Models.Price", b =>
                {
                    b.HasOne("TreatQuest.Models.SubChoice", "SubChoice")
                        .WithMany("Prices")
                        .HasForeignKey("SubChoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubChoice");
                });

            modelBuilder.Entity("TreatQuest.Models.SubChoice", b =>
                {
                    b.HasOne("TreatQuest.Models.SubOption", "SubOption")
                        .WithMany("SubChoice")
                        .HasForeignKey("SubOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubOption");
                });

            modelBuilder.Entity("TreatQuest.Models.SubOption", b =>
                {
                    b.HasOne("TreatQuest.Models.Option", "Option")
                        .WithMany("SubOptions")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Option");
                });

            modelBuilder.Entity("TreatQuest.Models.Option", b =>
                {
                    b.Navigation("SubOptions");
                });

            modelBuilder.Entity("TreatQuest.Models.SubChoice", b =>
                {
                    b.Navigation("Prices");
                });

            modelBuilder.Entity("TreatQuest.Models.SubOption", b =>
                {
                    b.Navigation("SubChoice");
                });
#pragma warning restore 612, 618
        }
    }
}
