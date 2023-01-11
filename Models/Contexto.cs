
using Microsoft.EntityFrameworkCore;

namespace ManagerHome.Models
{
    public class Contexto:DbContext
    {
        public Contexto(DbContextOptions<Contexto> options):base(options)
        {}
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration= new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json",false,true)
            .Build();
            optionsBuilder.(configuration.GetConnectionString("ConexaoBD"));
        }*/
        public DbSet<Pessoa> Pessoas{get;set;}
        
    }
}