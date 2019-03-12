using Microsoft.EntityFrameworkCore;
using VidzGabi.API.Models;

namespace VidzGabi.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Value> Values { get; set; }
    }
}