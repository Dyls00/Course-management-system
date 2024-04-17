using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Course_management_system;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cour> Cours { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=master;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cour>(entity =>
        {
            entity.HasKey(e => e.CoursId).HasName("PK__cours__2835BC470C81B514");

            entity.ToTable("cours");

            entity.Property(e => e.CoursId)
                .ValueGeneratedNever()
                .HasColumnName("cours_Id");
            entity.Property(e => e.DateDebutCours).HasColumnName("date_debut_cours");
            entity.Property(e => e.DateFinCours).HasColumnName("date_fin_cours");
            entity.Property(e => e.DureeCours).HasColumnName("duree_cours");
            entity.Property(e => e.NomCours)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom_cours");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.ParticipantId).HasName("PK__particip__4E027C2E5440F9E8");

            entity.ToTable("participant");

            entity.Property(e => e.ParticipantId)
                .ValueGeneratedNever()
                .HasColumnName("participant_Id");
            entity.Property(e => e.CoursId).HasColumnName("cours_Id");
            entity.Property(e => e.NomParticipant)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom_participant");

            entity.HasOne(d => d.Cours).WithMany(p => p.Participants)
                .HasForeignKey(d => d.CoursId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__participa__cours__278EDA44");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
