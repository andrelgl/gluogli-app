using Gluogli.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Gluogli
{
    public class GlougliDbCOntext : DbContext
    {


        public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory =
        new LoggerFactory(new[] {
            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);
            optionsBuilder.UseNpgsql("Host=localhost;Database=banco;Username=postgres;Password=12345");
        }
        public DbSet<Conteudo> Conteudo { get; set; }
        public DbSet<Pagina> Pagina { get; set; }
    }

}