
using CQRS_MEDIATR.Model;

namespace CQRS_MEDIATR.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Student> students { get; set; }
    }
}
