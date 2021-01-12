using Microsoft.EntityFrameworkCore;
using EFCorePractice.Model;
using Microsoft.Extensions.Logging;

namespace EFCorePractice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Alliance> Alliances { get; set; }
        public DbSet<Hero> Heros { get; set; }
        public DbSet<Mount> Mounts { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 联合主键
            modelBuilder.Entity<BattleHero>().HasKey(x => new { x.HeroId, x.BattleId });

            // 1对1
            modelBuilder.Entity<Mount>()
                .HasOne(x => x.Hero)
                .WithOne(x => x.Mount)
                .HasForeignKey<Mount>(x => x.HeroId);
        }
    }
}