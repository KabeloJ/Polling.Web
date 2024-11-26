using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public partial class PollDBContext : DbContext
{
    public PollDBContext()
    {
    }

    public PollDBContext(DbContextOptions<PollDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<Poll> Polls { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<SelectedOption> SelectedOptions { get; set; }

    public virtual DbSet<UsersVote> UsersVotes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Bootstrapper.ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PK_Answers");

            entity.ToTable("Answer");

            entity.Property(e => e.AnswerId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PollPublicId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.QuestionContent)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QuestionId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SequenceNo).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK_QuestionOpetions");

            entity.ToTable("Option");

            entity.Property(e => e.OptionContent)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QuestionId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Poll>(entity =>
        {
            entity.ToTable("Poll");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DatePublished).HasColumnType("datetime");
            entity.Property(e => e.PollDescription)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PollName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PublicId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK_PollQuestions");

            entity.ToTable("Question");

            entity.Property(e => e.QuestionId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PollId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.QuestionContent)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SequenceNo).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SelectedOption>(entity =>
        {
            entity.ToTable("SelectedOption");

            entity.Property(e => e.AnswerId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OptionContent)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsersVote>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.SelectedOptionId, e.PublicId }).HasName("PK_UsersVotes");

            entity.ToTable("UsersVote");

            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PublicId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AnswerId)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
