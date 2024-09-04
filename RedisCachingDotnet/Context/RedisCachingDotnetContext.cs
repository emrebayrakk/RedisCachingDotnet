using Microsoft.EntityFrameworkCore;
using RedisCachingDotnet.Models;

namespace RedisCachingDotnet.Context
{
    public class RedisCachingDotnetContext : DbContext
    {
        public RedisCachingDotnetContext(DbContextOptions<RedisCachingDotnetContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = "Data Source=DESKTOP-P87BUPQ;Initial Catalog=Sample.RedisCacheDotnet;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            optionsBuilder.UseSqlServer(connStr);
        }
        public DbSet<User> Users { get; set; }
    }
}
