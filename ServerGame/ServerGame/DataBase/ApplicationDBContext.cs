

using Microsoft.EntityFrameworkCore;
using ServerGame.Models;
using System;

namespace ServerGame.DataBase
{
    public class ApplicationDBContext : DbContext
    {
        private static string dbType;
        private static string _connectionString;
        public DbSet<GameResultModel> GameResult { get; set; }

        public static void SetDBOptions(string dataBaseType = "", string connectionString = "")
        {
            dbType = dataBaseType;
            _connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameResultModel>()
                .HasKey(o => new { o.PlayerId, o.GameId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (dbType.ToLower())
            {
                case "sqlserver":
                    optionsBuilder.UseSqlServer(_connectionString);
                    break;
                case "inmemorydatabase":
                    optionsBuilder.UseInMemoryDatabase("InMemoryDataBaseGameResult");
                    break;
                default:
                    optionsBuilder.UseInMemoryDatabase("InMemoryDataBaseGameResult");
                    break;
            }
        }
    }
}
