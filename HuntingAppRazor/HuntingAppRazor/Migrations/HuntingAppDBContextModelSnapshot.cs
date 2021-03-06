﻿// <auto-generated />
using System;
using HuntingAppRazor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HuntingAppRazor.Migrations
{
    [DbContext(typeof(HuntingAppDBContext))]
    partial class HuntingAppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HuntingAppRazor.Models.Hunts", b =>
                {
                    b.Property<Guid>("Uuid")
                        .HasColumnName("uuid");

                    b.Property<int?>("BucksSeen")
                        .HasColumnName("bucks_seen");

                    b.Property<int?>("DoesSeen")
                        .HasColumnName("does_seen");

                    b.Property<DateTime>("HuntEnd")
                        .HasColumnName("hunt_end")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("HuntStart")
                        .HasColumnName("hunt_start")
                        .HasColumnType("datetime");

                    b.Property<string>("Notes")
                        .HasColumnName("notes");

                    b.Property<string>("SightDetails")
                        .HasColumnName("sight_details");

                    b.Property<Guid>("StandUuid")
                        .HasColumnName("stand_uuid");

                    b.Property<int?>("UnknownSeen")
                        .HasColumnName("unknown_seen");

                    b.Property<Guid>("UserUuid")
                        .HasColumnName("user_uuid");

                    b.HasKey("Uuid");

                    b.HasIndex("StandUuid");

                    b.ToTable("Hunts");
                });

            modelBuilder.Entity("HuntingAppRazor.Models.Properties", b =>
                {
                    b.Property<Guid>("Uuid")
                        .HasColumnName("uuid");

                    b.Property<string>("Address")
                        .HasColumnName("address")
                        .HasMaxLength(10);

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<string>("State")
                        .HasColumnName("state")
                        .HasMaxLength(10);

                    b.Property<string>("Zip")
                        .HasColumnName("zip")
                        .HasMaxLength(10);

                    b.HasKey("Uuid");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("HuntingAppRazor.Models.PropertyAccess", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id");

                    b.Property<Guid>("PropertyUuid")
                        .HasColumnName("property_uuid");

                    b.Property<Guid>("UsersUuid")
                        .HasColumnName("users_uuid");

                    b.HasKey("Id");

                    b.HasIndex("PropertyUuid");

                    b.HasIndex("UsersUuid");

                    b.ToTable("PropertyAccess");
                });

            modelBuilder.Entity("HuntingAppRazor.Models.Sightings", b =>
                {
                    b.Property<Guid>("Uuid")
                        .HasColumnName("uuid");

                    b.Property<int?>("BucksSeen")
                        .HasColumnName("bucks_seen");

                    b.Property<int?>("DoesSeen")
                        .HasColumnName("does_seen");

                    b.Property<Guid>("HuntUuid")
                        .HasColumnName("hunt_uuid");

                    b.Property<string>("Notes")
                        .HasColumnName("notes")
                        .HasMaxLength(160)
                        .IsUnicode(false);

                    b.Property<DateTime>("SightDt")
                        .HasColumnName("sight_dt")
                        .HasColumnType("datetime");

                    b.Property<int?>("UnknownSeen")
                        .HasColumnName("unknown_seen");

                    b.HasKey("Uuid");

                    b.HasIndex("HuntUuid");

                    b.ToTable("Sightings");
                });

            modelBuilder.Entity("HuntingAppRazor.Models.Stands", b =>
                {
                    b.Property<Guid>("Uuid")
                        .HasColumnName("uuid");

                    b.Property<byte[]>("BackImg")
                        .HasColumnName("back_img")
                        .HasColumnType("image");

                    b.Property<byte[]>("FrontImg")
                        .HasColumnName("front_img")
                        .HasColumnType("image");

                    b.Property<byte[]>("LeftImg")
                        .HasColumnName("left_img")
                        .HasColumnType("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(50);

                    b.Property<Guid>("PropertyUuid")
                        .HasColumnName("property_uuid");

                    b.Property<byte[]>("RightImg")
                        .HasColumnName("right_img")
                        .HasColumnType("image");

                    b.HasKey("Uuid");

                    b.HasIndex("PropertyUuid");

                    b.ToTable("Stands");
                });

            modelBuilder.Entity("HuntingAppRazor.Models.Users", b =>
                {
                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("uuid")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnName("email_address")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasMaxLength(4000);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username")
                        .HasMaxLength(50);

                    b.HasKey("Uuid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HuntingAppRazor.Models.Hunts", b =>
                {
                    b.HasOne("HuntingAppRazor.Models.Stands", "StandUu")
                        .WithMany("Hunts")
                        .HasForeignKey("StandUuid")
                        .HasConstraintName("FK_Hunts_Stands");

                    b.HasOne("HuntingAppRazor.Models.Users", "Uu")
                        .WithOne("Hunts")
                        .HasForeignKey("HuntingAppRazor.Models.Hunts", "Uuid")
                        .HasConstraintName("FK_Hunts_User");
                });

            modelBuilder.Entity("HuntingAppRazor.Models.PropertyAccess", b =>
                {
                    b.HasOne("HuntingAppRazor.Models.Properties", "PropertyUu")
                        .WithMany("PropertyAccess")
                        .HasForeignKey("PropertyUuid")
                        .HasConstraintName("FK_PropertyAccess_Property");

                    b.HasOne("HuntingAppRazor.Models.Users", "UsersUu")
                        .WithMany("PropertyAccess")
                        .HasForeignKey("UsersUuid")
                        .HasConstraintName("FK_PropertyAccess_User");
                });

            modelBuilder.Entity("HuntingAppRazor.Models.Sightings", b =>
                {
                    b.HasOne("HuntingAppRazor.Models.Hunts", "HuntUu")
                        .WithMany("Sightings")
                        .HasForeignKey("HuntUuid")
                        .HasConstraintName("FK_Sightings_Hunts");
                });

            modelBuilder.Entity("HuntingAppRazor.Models.Stands", b =>
                {
                    b.HasOne("HuntingAppRazor.Models.Properties", "PropertyUu")
                        .WithMany("Stands")
                        .HasForeignKey("PropertyUuid")
                        .HasConstraintName("FK_Stands_Property");
                });
#pragma warning restore 612, 618
        }
    }
}
