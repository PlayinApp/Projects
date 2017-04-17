using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi;

namespace WebApi.Models
{
    public class EmpRepository
    {
        SampleEntities1 db = new SampleEntities1();
        public IEnumerable<Emplyee> GetAllEmplyees() {


            return db.Emplyees.ToList();

        }

        public Emplyee GetEmploybyid(int id) {

            return db.Emplyees.Where(x => x.ID == id).FirstOrDefault();

        }
        
    }

    public class Emplyee
    {
        public int ID { get; internal set; }
    }
}