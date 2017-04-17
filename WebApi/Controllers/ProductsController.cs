using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        SampleEntities1 db = new SampleEntities1();
        Product[] product = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        //public IEnumerable<Product> GetAllProducts()
        //{
        //  //  Employee emp = EmployeeContext.Employees.Where(e => e.Id == id).FirstOrDefault();


        //    return product;
        //}

        public HttpResponseMessage getjson() {

            
                // Employee emp = EmployeeContext.Employees.Where(e => e.Id == id).FirstOrDefault();

                var resp = new HttpResponseMessage { Content = new StringContent("[{\"Name\":\"ABC\"},[{\"A\":\"1\"},{\"B\":\"2\"},{\"C\":\"3\"}]]", System.Text.Encoding.UTF8, "application/json") };

    


                return Request.CreateResponse(HttpStatusCode.InternalServerError);


           




        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = this.product.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }



    }
}
