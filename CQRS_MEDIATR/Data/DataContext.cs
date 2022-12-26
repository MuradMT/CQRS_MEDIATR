
using CQRS_MEDIATR.Model;
using System.Configuration;

namespace CQRS_MEDIATR.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source = MURADMT; Initial Catalog = CQRSMEDIATR; Integrated Security = True; TrustServerCertificate = True;");
        //}
        //public DataContext()
        //{

        //}
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    Age = 19,
                    Name = "Murad",
                    Surname = "Mammadzada",
                    Hobby = "Programming"
                });
        }
    }
}
