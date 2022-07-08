using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Data
{
    class ApplicationDbContextv : DbContext
    {
        private string sqlConnectionString = @"C:\USERS\DANIL\SOURCE\REPOS\TASKLIST\TASKLIST\DATA\DATABASETASK.MDF";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(sqlConnectionString);
        }
    }
}
