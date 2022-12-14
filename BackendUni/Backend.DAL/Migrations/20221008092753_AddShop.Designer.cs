// <auto-generated />
using System;
using Backend.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.DAL.Migrations
{
    [DbContext(typeof(GamificationDbContext))]
    [Migration("20221008092753_AddShop")]
    partial class AddShop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Backend.DAL.Models.AnswerVariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("QuestionnaireId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionnaireId");

                    b.ToTable("AnswerVariants");
                });

            modelBuilder.Entity("Backend.DAL.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDone")
                        .HasColumnType("boolean");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Backend.DAL.Models.CompletedTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CompleteDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("TaskId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("CompletedTasks");
                });

            modelBuilder.Entity("Backend.DAL.Models.GameRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GameRoles");
                });

            modelBuilder.Entity("Backend.DAL.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("TaskId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Backend.DAL.Models.Mark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageLink")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("Backend.DAL.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<string>("ImageLink")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Backend.DAL.Models.Questionnaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Questionnaires");
                });

            modelBuilder.Entity("Backend.DAL.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Backend.DAL.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImageLink")
                        .HasColumnType("text");

                    b.Property<bool>("IsAnnouncement")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Backend.DAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageLink")
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PrivateKey")
                        .HasColumnType("text");

                    b.Property<string>("PublicKey")
                        .HasColumnType("text");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.DAL.Models.UsersQuestionnaireAnswers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnswerVariantId")
                        .HasColumnType("integer");

                    b.Property<int?>("QuestionnaireId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AnswerVariantId");

                    b.HasIndex("QuestionnaireId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersQuestionnaireAnswers");
                });

            modelBuilder.Entity("GameRoleMark", b =>
                {
                    b.Property<int>("GameRolesId")
                        .HasColumnType("integer");

                    b.Property<int>("MarksId")
                        .HasColumnType("integer");

                    b.HasKey("GameRolesId", "MarksId");

                    b.HasIndex("MarksId");

                    b.ToTable("GameRoleMark");
                });

            modelBuilder.Entity("MarkTask", b =>
                {
                    b.Property<int>("MarksId")
                        .HasColumnType("integer");

                    b.Property<int>("TasksId")
                        .HasColumnType("integer");

                    b.HasKey("MarksId", "TasksId");

                    b.HasIndex("TasksId");

                    b.ToTable("MarkTask");
                });

            modelBuilder.Entity("QuestionnaireUser", b =>
                {
                    b.Property<int>("QuestionnairesId")
                        .HasColumnType("integer");

                    b.Property<int>("TargetUsersId")
                        .HasColumnType("integer");

                    b.HasKey("QuestionnairesId", "TargetUsersId");

                    b.HasIndex("TargetUsersId");

                    b.ToTable("QuestionnaireUser");
                });

            modelBuilder.Entity("TaskUser", b =>
                {
                    b.Property<int>("TargetUsersId")
                        .HasColumnType("integer");

                    b.Property<int>("TasksId")
                        .HasColumnType("integer");

                    b.HasKey("TargetUsersId", "TasksId");

                    b.HasIndex("TasksId");

                    b.ToTable("TaskUser");
                });

            modelBuilder.Entity("Backend.DAL.Models.AnswerVariant", b =>
                {
                    b.HasOne("Backend.DAL.Models.Questionnaire", null)
                        .WithMany("AnswerVariants")
                        .HasForeignKey("QuestionnaireId");
                });

            modelBuilder.Entity("Backend.DAL.Models.CartItem", b =>
                {
                    b.HasOne("Backend.DAL.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Backend.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.DAL.Models.CompletedTask", b =>
                {
                    b.HasOne("Backend.DAL.Models.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId");

                    b.HasOne("Backend.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.DAL.Models.Like", b =>
                {
                    b.HasOne("Backend.DAL.Models.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId");

                    b.HasOne("Backend.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.DAL.Models.Task", b =>
                {
                    b.HasOne("Backend.DAL.Models.User", "Creator")
                        .WithMany("CreatedTasks")
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Backend.DAL.Models.User", b =>
                {
                    b.HasOne("Backend.DAL.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Backend.DAL.Models.UsersQuestionnaireAnswers", b =>
                {
                    b.HasOne("Backend.DAL.Models.AnswerVariant", "AnswerVariant")
                        .WithMany()
                        .HasForeignKey("AnswerVariantId");

                    b.HasOne("Backend.DAL.Models.Questionnaire", "Questionnaire")
                        .WithMany()
                        .HasForeignKey("QuestionnaireId");

                    b.HasOne("Backend.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("AnswerVariant");

                    b.Navigation("Questionnaire");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameRoleMark", b =>
                {
                    b.HasOne("Backend.DAL.Models.GameRole", null)
                        .WithMany()
                        .HasForeignKey("GameRolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.DAL.Models.Mark", null)
                        .WithMany()
                        .HasForeignKey("MarksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarkTask", b =>
                {
                    b.HasOne("Backend.DAL.Models.Mark", null)
                        .WithMany()
                        .HasForeignKey("MarksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.DAL.Models.Task", null)
                        .WithMany()
                        .HasForeignKey("TasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuestionnaireUser", b =>
                {
                    b.HasOne("Backend.DAL.Models.Questionnaire", null)
                        .WithMany()
                        .HasForeignKey("QuestionnairesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("TargetUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskUser", b =>
                {
                    b.HasOne("Backend.DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("TargetUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.DAL.Models.Task", null)
                        .WithMany()
                        .HasForeignKey("TasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.DAL.Models.Questionnaire", b =>
                {
                    b.Navigation("AnswerVariants");
                });

            modelBuilder.Entity("Backend.DAL.Models.User", b =>
                {
                    b.Navigation("CreatedTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
