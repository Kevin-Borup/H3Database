using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp_DatabaseFirst.Models;

public partial class SchoolDBRingsted1Context : DbContext
{
    public SchoolDBRingsted1Context()
    {
    }

    public SchoolDBRingsted1Context(DbContextOptions<SchoolDBRingsted1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<LibraryCard> LibraryCards { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQL2019;Database=SchoolDBRingsted1;Encrypt=False;Trusted_Connection=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Addresse__3214EC27E9791045");

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseID).HasName("PK__Courses__C92D718750F193D9");

            entity.Property(e => e.CourseID).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeID).HasName("PK__Grades__54F87A379A37D90F");

            entity.Property(e => e.GradeID).ValueGeneratedNever();
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LibraryCard>(entity =>
        {
            entity.HasKey(e => e.UserID).HasName("PK__LibraryC__1788CCACEB43875F");

            entity.Property(e => e.UserID).ValueGeneratedNever();
            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithOne(p => p.LibraryCard)
                .HasForeignKey<LibraryCard>(d => d.UserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LibraryCa__UserI__3E1D39E1");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Persons__3214EC272BB401AD");

            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Address).WithMany(p => p.People)
                .HasForeignKey(d => d.AddressID)
                .HasConstraintName("FK__Persons__Address__3B40CD36");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.PersonID).HasName("PK__Students__AA2FFB857813EE85");

            entity.HasIndex(e => e.StudentID, "UQ__Students__32C52A78BF53C87A").IsUnique();

            entity.Property(e => e.PersonID).ValueGeneratedNever();

            entity.HasOne(d => d.Person).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.PersonID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__Person__41EDCAC5");

            entity.HasMany(d => d.Courses).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentCourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentCo__Cours__4D5F7D71"),
                    l => l.HasOne<Student>().WithMany()
                        .HasPrincipalKey("StudentID")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentCo__Stude__4C6B5938"),
                    j =>
                    {
                        j.HasKey("StudentID", "CourseID").HasName("PK__StudentC__5E57FD615B482283");
                        j.ToTable("StudentCourses");
                    });

            entity.HasMany(d => d.Grades).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentGrade",
                    r => r.HasOne<Grade>().WithMany()
                        .HasForeignKey("GradeID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentGr__Grade__51300E55"),
                    l => l.HasOne<Student>().WithMany()
                        .HasPrincipalKey("StudentID")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentGr__Stude__503BEA1C"),
                    j =>
                    {
                        j.HasKey("StudentID", "GradeID").HasName("PK__StudentG__578AADDA82164904");
                        j.ToTable("StudentGrades");
                    });
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.PersonID).HasName("PK__Teachers__AA2FFB857D29BF98");

            entity.HasIndex(e => e.TeacherID, "UQ__Teachers__EDF25945DBF975D4").IsUnique();

            entity.Property(e => e.PersonID).ValueGeneratedNever();

            entity.HasOne(d => d.Person).WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(d => d.PersonID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Teachers__Person__45BE5BA9");

            entity.HasMany(d => d.Courses).WithMany(p => p.Teachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeacherCourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TeacherCo__Cours__55009F39"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasPrincipalKey("TeacherID")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TeacherCo__Teach__540C7B00"),
                    j =>
                    {
                        j.HasKey("TeacherID", "CourseID").HasName("PK__TeacherC__81608E5C724E541B");
                        j.ToTable("TeacherCourses");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
