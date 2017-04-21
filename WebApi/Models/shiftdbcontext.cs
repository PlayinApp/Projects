using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Configuration;

namespace WebApi.Models
{
    public class shiftdbcontext:DbContext
    {
        public DbSet<Shift> shifts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shift>().MapToStoredProcedures(
               p=>p.Insert(i => i.HasName("InsertEmployee")
               .Parameter(n => n.shiftname, "test") .Parameter(n => n.Command, "INSERT") ) 
                
                
                );
                
            base.OnModelCreating(modelBuilder);
        }


    }
}