using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Entities;

namespace Task.Repository.Data
{
    public class TaskContext : DbContext
    {

        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);


        }

        public DbSet<Product> Product { get; set; }


    }
}
