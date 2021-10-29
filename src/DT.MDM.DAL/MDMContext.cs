using DT.MDM.Models;
using Microsoft.EntityFrameworkCore;

namespace DT.MDM.DAL
{
    public class MDMContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Resource> Resources { get; set; }

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
    }
}
