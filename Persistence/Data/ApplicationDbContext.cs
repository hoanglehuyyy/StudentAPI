using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Persistence.Data
{
	public class ApplicationDbContext : DbContext
	{
        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=localhost;Database=StudentManagement;User Id=SA;Password=Password.1;TrustServerCertificate=True;")
            //    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add primary key for StudentSubject table
            modelBuilder.Entity<StudentSubject>().HasKey(e => new {e.StudentId, e.SubjectId});

            // Set Subject code field of Subject table is unique
            modelBuilder.Entity<Subject>(e =>
            {
                e.HasIndex(e => e.SubjectCode).IsUnique();
            });

            // Add data into User table
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "admin", Password = "123456", Name = "Admin", Role = "admin" },
                new User { Id = 2, UserName = "user", Password = "123456", Name = "User", Role = "user"});

            // Add data into Class table
            modelBuilder.Entity<Class>().HasData(
                new Class { Id = 1, ClassName = "6A", Grade = 6 },
                new Class { Id = 2, ClassName = "6B", Grade = 6 },
                new Class { Id = 3, ClassName = "6C", Grade = 6 },
                new Class { Id = 4, ClassName = "6D", Grade = 6 },
                new Class { Id = 5, ClassName = "7A", Grade = 7 },
                new Class { Id = 6, ClassName = "7B", Grade = 7 },
                new Class { Id = 7, ClassName = "7C", Grade = 7 },
                new Class { Id = 8, ClassName = "7D", Grade = 7 },
                new Class { Id = 9, ClassName = "8A", Grade = 8 },
                new Class { Id = 10, ClassName = "8B", Grade = 8 },
                new Class { Id = 11, ClassName = "8C", Grade = 8 },
                new Class { Id = 12, ClassName = "8D", Grade = 8 },
                new Class { Id = 13, ClassName = "9A", Grade = 9 },
                new Class { Id = 14, ClassName = "9B", Grade = 9 },
                new Class { Id = 15, ClassName = "9C", Grade = 9 },
                new Class { Id = 16, ClassName = "9D", Grade = 9 });

            // Add data into Student table
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FirstName = "Hoang", MiddleName = "Huy", LastName = "Le", Birthday = new DateTime(2001, 11, 14), Country = "Vietnam", Address = "Hoa Lac, Thach That, Ha Noi", PhoneNumber = "0369473014", ClassId = 1 },
                new Student { Id = 2, FirstName = "Sang", MiddleName = "Huu", LastName = "Nguyen", Birthday = new DateTime(1999, 10, 10), Country = "Vietnam", Address = "Nguyen Trai, Thanh Xuan, Ha Noi", PhoneNumber = "0987654321", ClassId = 1 },
                new Student { Id = 3, FirstName = "Quan", MiddleName = "Tran", LastName = "Nguyen", Birthday = new DateTime(2001, 09, 012), Country = "Vietnam", Address = "Truong Chinh, Thanh Xuan, Ha Noi", PhoneNumber = "0975328374", ClassId = 1 },
                new Student { Id = 4, FirstName = "Vinh", MiddleName = "Xuan", LastName = "Pham", Birthday = new DateTime(1999, 07, 06), Country = "Vietnam", Address = "Linh Nam, Hoang Mai, Ha Noi", PhoneNumber = "0982376178", ClassId = 2 },
                new Student { Id = 5, FirstName = "Thi", MiddleName = "Viet", LastName = "Pham", Birthday = new DateTime(1997, 07, 30), Country = "United State", Address = "New York", PhoneNumber = "0013829372", ClassId = 2 },
                new Student { Id = 6, FirstName = "Hang", MiddleName = "Thi Thuy", LastName = "Le", Birthday = new DateTime(1996, 03, 28), Country = "United State", Address = "California", PhoneNumber = "001984728487", ClassId = 2 },
                new Student { Id = 7, FirstName = "Hong", MiddleName = "Thi", LastName = "Nguyen", Birthday = new DateTime(1995, 05, 25), Country = "United State", Address = "Texas", PhoneNumber = "001839265221", ClassId = 2 },
                new Student { Id = 8, FirstName = "Thien", MiddleName = "Van", LastName = "Vu", Birthday = new DateTime(1990, 01, 16), Country = "France", Address = "Paris", PhoneNumber = "00339283921793", ClassId = 5 },
                new Student { Id = 9, FirstName = "Hoc", MiddleName = "Van", LastName = "Pham", Birthday = new DateTime(1992, 03, 24), Country = "France", Address = "Lyon", PhoneNumber = "00338292729282", ClassId = 5 },
                new Student { Id = 10, FirstName = "Nam", MiddleName = "Hoai", LastName = "Vu", Birthday = new DateTime(2000, 12, 25), Country = "China", Address = "HongKong", PhoneNumber = "011852892023928", ClassId = 9 },
                new Student { Id = 11, FirstName = "Ly", MiddleName = "Khanh", LastName = "Dong", Birthday = new DateTime(2001, 02, 28), Country = "China", Address = "Macau", PhoneNumber = "00868093209", ClassId = 10 },
                new Student { Id = 12, FirstName = "Thao", MiddleName = "Phuong", LastName = "Nguyen", Birthday = new DateTime(1998, 08, 12), Country = "China", Address = "Beijing", PhoneNumber = "00869382029", ClassId = 14 },
                new Student { Id = 13, FirstName = "Dao", MiddleName = "Thi", LastName = "Vu", Birthday = new DateTime(1994, 05, 18), Country = "Thailand", Address = "Bangkok", PhoneNumber = "006698230923", ClassId = 16 }
                );

            // Add data into Subject table
            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, SubjectCode = "M001", SubjectName = "Math" },
                new Subject { Id = 2, SubjectCode = "L001", SubjectName = "Literature" },
                new Subject { Id = 3, SubjectCode = "E001", SubjectName = "English" },
                new Subject { Id = 4, SubjectCode = "P001", SubjectName = "Physics" },
                new Subject { Id = 5, SubjectCode = "C001", SubjectName = "Chemistry" },
                new Subject { Id = 6, SubjectCode = "B001", SubjectName = "Biology" },
                new Subject { Id = 7, SubjectCode = "H001", SubjectName = "History" },
                new Subject { Id = 8, SubjectCode = "G001", SubjectName = "Geography" },
                new Subject { Id = 9, SubjectCode = "CE001", SubjectName = "Civic Education" },
                new Subject { Id = 10, SubjectCode = "PE001", SubjectName = "Physical Education" });

            // Add data into StudentSubjectTable
            modelBuilder.Entity<StudentSubject>().HasData(
                new StudentSubject { StudentId = 1, SubjectId = 1, Mark = 9.5f },
                new StudentSubject { StudentId = 1, SubjectId = 3, Mark = 8.25f },
                new StudentSubject { StudentId = 1, SubjectId = 4, Mark = 8.5f },
                new StudentSubject { StudentId = 2, SubjectId = 1, Mark = 9.5f },
                new StudentSubject { StudentId = 2, SubjectId = 2, Mark = 7.5f },
                new StudentSubject { StudentId = 2, SubjectId = 3, Mark = 9.0f },
                new StudentSubject { StudentId = 3, SubjectId = 4, Mark = 7.5f },
                new StudentSubject { StudentId = 3, SubjectId = 5, Mark = 6.75f },
                new StudentSubject { StudentId = 4, SubjectId = 6, Mark = 5.25f },
                new StudentSubject { StudentId = 5, SubjectId = 7, Mark = 5.75f },
                new StudentSubject { StudentId = 6, SubjectId = 8, Mark = 7.0f },
                new StudentSubject { StudentId = 6, SubjectId = 9, Mark = 8.75f },
                new StudentSubject { StudentId = 7, SubjectId = 10, Mark = 9.5f },
                new StudentSubject { StudentId = 8, SubjectId = 1, Mark = 10.0f },
                new StudentSubject { StudentId = 9, SubjectId = 2, Mark = 7.5f },
                new StudentSubject { StudentId = 10, SubjectId = 3, Mark = 8.5f },
                new StudentSubject { StudentId = 11, SubjectId = 1, Mark = 6.0f },
                new StudentSubject { StudentId = 12, SubjectId = 5, Mark = 7.25f },
                new StudentSubject { StudentId = 13, SubjectId = 6, Mark = 8.0f });
        }
    }
}

