using DT.MDM.Models;
using Microsoft.EntityFrameworkCore;

namespace DT.MDM.DAL
{
    public class MDMContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Field> Fields { get; set; }

        public DbSet<ChoiceField> ChoiceFields { get; set; }

        public DbSet<ChoiceValue> ChoiceValues { get; set; }

        public DbSet<Entity> Entities { get; set; }

        public MDMContext(DbContextOptions<MDMContext> options): base(options)
        {

        }

        public MDMContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!string.IsNullOrEmpty(_connectionString))
                optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Field>().HasDiscriminator(a => a.DataType);
        }
    }
}
