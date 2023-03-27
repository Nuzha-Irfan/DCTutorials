using API_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        List <DataIntermed> list = new List<DataIntermed> ();
        // GET api/values
        public int  Get()
        {
            list = AccountList.AllData();
            return list.Count();
        }








    }
}
