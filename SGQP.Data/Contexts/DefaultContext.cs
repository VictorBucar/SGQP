using Microsoft.EntityFrameworkCore;
using SGQP.Domain.Entities;

namespace SGQP.Data.Contexts
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions options) : base(options)
        {

        }

        public  DbSet<QuestionDescription> QuestionDescriptions { get; set; }

        public  DbSet<QuestionAlternative> QuestionAlternatives { get; set; }

        public  DbSet<Theme> Themes { get; set; }

        public  DbSet<User> Users { get; set; }

        public  DbSet<Discipline> Disciplines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>().HasKey(x => x.Id);

            //modelBuilder.Entity<QuestionDescription>().HasKey(x => x.Id);
        }
    }
}
