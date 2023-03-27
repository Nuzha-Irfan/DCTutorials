
using SQL_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Newtonsoft.Json;
using System.Security.Principal;

namespace SQL_WebAPI.Controllers
{
    public class DatabaseGenarateController : ApiController
    {

        private BankEntities1 db = new BankEntities1();

       
        public IHttpActionResult Post()
        {

            for(int i = 0; i <= 100; i++)
            {
                Account account = new Account();
                account = genartor.getDetails();
                db.Accounts.Add(account);
                db.SaveChanges();
            }
            
                
                    return StatusCode(HttpStatusCode.NoContent); ;
                
            
           
        }
    }
}
