using SQL_BusinessAPI.Models;
using SQL_WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ServiceModel;
using System.Web.Mvc;
using SQL_WebAPI.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SQL_BusinessAPI.Controllers
{
    public class AccountDataController : ApiController
    {
        private  BankEntities1 db = new BankEntities1();
        public IHttpActionResult BulkData()
        {
            // This is only for show by default one row for insert data to the database
            List<Account> ci = new List<Account> { new Account { Id = 0, FirstName = "", LastName = "", AccountNo = 0, pin = 0, balance = 0, ImageSource = "" } };
            return Ok(ci);


        }

    
       
        public IHttpActionResult Post()
        {
            List<Account> ci;
            ci = DataGenarate.getDetails();
            if (ModelState.IsValid)
            {
                BankEntities1 db = new BankEntities1();
                
                    foreach (var i in ci)
                    {
                      db.Accounts.Add(i);
                    
                    }
                    db.SaveChanges();
                   
                    ModelState.Clear();
                    ci = new List<Account> { new Account { Id = 0, FirstName = "", LastName = "", AccountNo = 0, pin = 0, balance = 0, ImageSource = "" } };
                
            }
            return Ok(ci);
        }
    }
}
