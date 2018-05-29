using System.IO;
using LawInOrderApp.Domain.Models;
using LawInOrderApp.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LawInOrderApp.Infra.Data.Context
{
    public class LawInOrderAppContext : DbContext
    {
        public DbSet<TimeSheet> TimeSheets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.ApplyConfiguration(new TimeSheetMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")    
                .Build();

            optionsBuilder.UseSqlServer(config
                                       .GetConnectionString("DefaultConnection"
                                                           ));
        }
    }
}
