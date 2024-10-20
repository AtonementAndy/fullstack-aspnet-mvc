using BeeEngineering.Domain.Models;
using BeeEngineering.Models;
using Microsoft.EntityFrameworkCore;

namespace BeeEngineering.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CandidateModel> Candidates { get; set; } = default!;
        public DbSet<Login> Logins { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateModel>()
                        .ToTable("Candidates");

            modelBuilder.Entity<CandidateModel>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<CandidateModel>()
                        .Property(x => x.Id)
                        .ValueGeneratedOnAdd();

            modelBuilder.Entity<CandidateModel>()
                        .Property(n => n.Name)
                        .IsRequired();

            modelBuilder.Entity<CandidateModel>()
                        .Property(s => s.Surname)
                        .IsRequired();

            modelBuilder.Entity<CandidateModel>()
                        .Property(c => c.Country)
                        .IsRequired();
            modelBuilder.Entity<CandidateModel>()
                        .Property(a => a.IsActive);                                                    

            modelBuilder.Entity<Login>()
                        .ToTable("Logins");

            modelBuilder.Entity<Login>()
                        .HasKey(x => x.Id);                            

            modelBuilder.Entity<Login>()
                        .Property(x => x.Id)
                        .ValueGeneratedOnAdd();            

            modelBuilder.Entity<Login>()
                        .Property(e => e.Email)
                        .IsRequired();

            modelBuilder.Entity<Login>()
                        .Property(p => p.Password)
                        .IsRequired();
        }
    }
}
