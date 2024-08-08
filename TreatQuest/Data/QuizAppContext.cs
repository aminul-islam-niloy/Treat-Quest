using Microsoft.EntityFrameworkCore;
using TreatQuest.Models;

namespace TreatQuest.Data
{
    public class QuizAppContext: DbContext
    {
        public QuizAppContext(DbContextOptions<QuizAppContext> options) : base(options)
        {

        }
        public DbSet<Option> Options { get; set; }
        public DbSet<SubOption> SubOptions { get; set; }
        public DbSet<SubChoice> SubChoices { get; set; }
        public DbSet<Price> Prices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Option-SubOption relationship
            modelBuilder.Entity<SubOption>()
                .HasOne(s => s.Option)
                .WithMany(o => o.SubOptions)
                .HasForeignKey(s => s.OptionId);

            // SubOption-SubChoice relationship
            modelBuilder.Entity<SubChoice>()
                .HasOne(sc => sc.SubOption)
                .WithMany(so => so.SubChoice)
                .HasForeignKey(sc => sc.SubOptionId);
        }
    }


}
