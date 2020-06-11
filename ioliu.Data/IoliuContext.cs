using ioliu.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ioliu.Data
{
   public class IoliuContext:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=47.106.166.10;DataBase=ioliu;uid=sa;pwd=df727123.");         
               
        //}

      public IoliuContext(DbContextOptions<IoliuContext> options):base(options)
        {

        }
       public DbSet<SystemUsers> systemUsers { get; set; }

    }
}
