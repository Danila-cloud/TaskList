using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Models.Project> Projects { get; set; }

        private string sqlConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\danil\source\repos\TaskList\TaskList\Data\DatabaseTask.mdf;Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(sqlConnectionString);
        }
    }
}
