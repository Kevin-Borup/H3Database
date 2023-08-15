using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_DatabaseFirst.Models;

public partial class SchoolDbringsted1Context : DbContext
{
    public SchoolDbringsted1Context()
    {
    }

    public SchoolDbringsted1Context(DbContextOptions<SchoolDbringsted1Context> options)
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
            entity.HasKey(e => e.Id).HasName("PK__Addresse__3214EC27E9791045");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
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
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D718750F193D9");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("CourseID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grades__54F87A379A37D90F");

            entity.Property(e => e.GradeId)
                .ValueGeneratedNever()
                .HasColumnName("GradeID");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LibraryCard>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__LibraryC__1788CCACEB43875F");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithOne(p => p.LibraryCard)
                .HasForeignKey<LibraryCard>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LibraryCa__UserI__3E1D39E1");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persons__3214EC272BB401AD");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
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
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK__Persons__Address__3B40CD36");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Students__AA2FFB857813EE85");

            entity.HasIndex(e => e.StudentId, "UQ__Students__32C52A78BF53C87A").IsUnique();

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("PersonID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Person).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students__Person__41EDCAC5");

            entity.HasMany(d => d.Courses).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentCourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentCo__Cours__4D5F7D71"),
                    l => l.HasOne<Student>().WithMany()
                        .HasPrincipalKey("StudentId")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentCo__Stude__4C6B5938"),
                    j =>
                    {
                        j.HasKey("StudentId", "CourseId").HasName("PK__StudentC__5E57FD615B482283");
                        j.ToTable("StudentCourses");
                        j.IndexerProperty<int>("StudentId").HasColumnName("StudentID");
                        j.IndexerProperty<Guid>("CourseId").HasColumnName("CourseID");
                    });

            entity.HasMany(d => d.Grades).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentGrade",
                    r => r.HasOne<Grade>().WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentGr__Grade__51300E55"),
                    l => l.HasOne<Student>().WithMany()
                        .HasPrincipalKey("StudentId")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__StudentGr__Stude__503BEA1C"),
                    j =>
                    {
                        j.HasKey("StudentId", "GradeId").HasName("PK__StudentG__578AADDA82164904");
                        j.ToTable("StudentGrades");
                        j.IndexerProperty<int>("StudentId").HasColumnName("StudentID");
                        j.IndexerProperty<Guid>("GradeId").HasColumnName("GradeID");
                    });
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__Teachers__AA2FFB857D29BF98");

            entity.HasIndex(e => e.TeacherId, "UQ__Teachers__EDF25945DBF975D4").IsUnique();

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("PersonID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Person).WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Teachers__Person__45BE5BA9");

            entity.HasMany(d => d.Courses).WithMany(p => p.Teachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeacherCourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TeacherCo__Cours__55009F39"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasPrincipalKey("TeacherId")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TeacherCo__Teach__540C7B00"),
                    j =>
                    {
                        j.HasKey("TeacherId", "CourseId").HasName("PK__TeacherC__81608E5C724E541B");
                        j.ToTable("TeacherCourses");
                        j.IndexerProperty<int>("TeacherId").HasColumnName("TeacherID");
                        j.IndexerProperty<Guid>("CourseId").HasColumnName("CourseID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
