namespace BELibrary.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ELearningDBContext : DbContext
    {
        public ELearningDBContext()
            : base("name=ELearningDBContext")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StudentSubject> StudentSubjects { get; set; }
        public virtual DbSet<StudentTest> StudentTests { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<ExamHistory> ExamHistories { get; set; }
        public virtual DbSet<ExamResults> ExamResults { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.LanguageId)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Ratings)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Subjects)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.UrlDocument)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Lecture>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Lecture>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Lecture>()
                .Property(e => e.UrlVideo)
                .IsUnicode(false);

            modelBuilder.Entity<Lecture>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Lecture)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rating>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<StudentSubject>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<StudentTest>()
                .Property(e => e.FileAnswer)
                .IsUnicode(false);

            modelBuilder.Entity<StudentTest>()
                .Property(e => e.ReplyFile)
                .IsUnicode(false);

            modelBuilder.Entity<StudentTest>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Documents)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Lectures)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.StudentSubjects)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.TeacherSubjects)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TeacherSubject>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LinkAvata)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.StudentSubjects)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TeacherSubjects)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}