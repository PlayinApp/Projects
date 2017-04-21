using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Webmvc.Models;

namespace Webmvc.Models
{
    public class shiftdbcontext : DbContext
    {
        public DbSet<Shift> shifts { get; set; }

        public shiftdbcontext()
             : base("ConnectionString")
                  {

        }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Shift>().MapToStoredProcedures(
        //       p => p.Insert(i => i.HasName("sp_shift")
        //         .Parameter(n => n.shiftname, "test").Parameter(n => n.Command, "INSERT"))

        //        );

        //    base.OnModelCreating(modelBuilder);
        //}


    }
}