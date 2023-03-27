using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc.Routing;
using System.Xml.Linq;

using Newtonsoft.Json;
using SQL_WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {

        private BankEntities1 db = new BankEntities1();


        // POST api/<controller>
        [Route("{searchText}")]
        [HttpGet]
        public Account Search(string searchText)
        {
            List<Account> programs = new List<Account>();
            Account returnData = new Account();
            try
            {
                // Using SteamReader to read the text file line one-by-one
                programs = db.Accounts.ToList();

                foreach (Account account in programs)
                {
                    if (String.Equals(account.LastName, searchText, StringComparison.OrdinalIgnoreCase))
                    {
                        returnData=account;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading from " + e.StackTrace + "\nMessage = " + e.Message);
            }
            return returnData;
        }



    }
}