﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfoliOSS.ModernData;

#nullable disable

namespace PortfoliOSS.ModernData.Migrations
{
    [DbContext(typeof(PortfoliOSSDBContext))]
    partial class PortfoliOSSDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OrganizationUser", b =>
                {
                    b.Property<int>("OrganizationsOrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("OrganizationsOrganizationId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("OrganizationUser");
                });

            modelBuilder.Entity("PortfoliOSS.ModernData.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganizationId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("PortfoliOSS.ModernData.PullRequest", b =>
                {
                    b.Property<long>("PullRequestId")
                        .HasColumnType("bigint");

                    b.Property<int>("AuthorUserId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsMerged")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("MergedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<long>("RepositoryRepoId")
                        .HasColumnType("bigint");

                    b.HasKey("PullRequestId");

                    b.HasIndex("AuthorUserId");

                    b.HasIndex("RepositoryRepoId");

                    b.ToTable("PullRequests");
                });

            modelBuilder.Entity("PortfoliOSS.ModernData.Repository", b =>
                {
                    b.Property<long>("RepoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RepoId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserId");

                    b.ToTable("Repositories");
                });

            modelBuilder.Entity("PortfoliOSS.ModernData.User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrganizationUser", b =>
                {
                    b.HasOne("PortfoliOSS.ModernData.Organization", null)
                        .WithMany()
                        .HasForeignKey("OrganizationsOrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortfoliOSS.ModernData.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PortfoliOSS.ModernData.PullRequest", b =>
                {
                    b.HasOne("PortfoliOSS.ModernData.User", "Author")
                        .WithMany("PullRequests")
                        .HasForeignKey("AuthorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortfoliOSS.ModernData.Repository", "Repository")
                        .WithMany("PullRequests")
                        .HasForeignKey("RepositoryRepoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Repository");
                });

            modelBuilder.Entity("PortfoliOSS.ModernData.Repository", b =>
                {
                    b.HasOne("PortfoliOSS.ModernData.Organization", null)
                        .WithMany("Repositories")
                        .HasForeignKey("OrganizationId");

                    b.HasOne("PortfoliOSS.ModernData.User", null)
                        .WithMany("Repositories")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PortfoliOSS.ModernData.Organization", b =>
                {
                    b.Navigation("Repositories");
                });

            modelBuilder.Entity("PortfoliOSS.ModernData.Repository", b =>
                {
                    b.Navigation("PullRequests");
                });

            modelBuilder.Entity("PortfoliOSS.ModernData.User", b =>
                {
                    b.Navigation("PullRequests");

                    b.Navigation("Repositories");
                });
#pragma warning restore 612, 618
        }
    }
}
