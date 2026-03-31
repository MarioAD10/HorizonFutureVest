using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Persistence
{
    public class InvestmentAppContext : DbContext
    {
        public InvestmentAppContext(DbContextOptions<InvestmentAppContext> options) : base(options) { }

        public DbSet<Country> Countries => Set<Country>();
        public DbSet<MacroIndicator> MacroIndicators => Set<MacroIndicator>();
        public DbSet<CountryIndicator> CountryIndicators => Set<CountryIndicator>();
        public DbSet<ReturnRateConfig> ReturnRateConfigs => Set<ReturnRateConfig>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);

            //Configuración única: nombre de país no se repite
            modelBuilder.Entity<Country>()
                .HasIndex(c => c.Name)
                .IsUnique();

            // Configuración única: código ISO no se repite
            modelBuilder.Entity<Country>()
                .HasIndex(c => c.IsoCode)
                .IsUnique();

            // Relación: un país puede tener muchos indicadores
            modelBuilder.Entity<CountryIndicator>()
                .HasOne(ci => ci.Country)
                .WithMany(c => c.Indicators)
                .HasForeignKey(ci => ci.CountryId);

            // Relación: un macroindicador puede estar en muchos CountryIndicators
            modelBuilder.Entity<CountryIndicator>()
                .HasOne(ci => ci.MacroIndicator)
                .WithMany(mi => mi.CountryIndicators)
                .HasForeignKey(ci => ci.MacroIndicatorId);
        }
    }
}
