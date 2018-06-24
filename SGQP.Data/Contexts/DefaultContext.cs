using Microsoft.EntityFrameworkCore;
using SGQP.Domain.Entities;

namespace SGQP.Data.Contexts
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<QuestionDescription> QuestionDescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
