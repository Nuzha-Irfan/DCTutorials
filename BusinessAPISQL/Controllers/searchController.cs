using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Web.Http;
using Newtonsoft.Json;
using RestSharp;
using System.Xml.Linq;
using SQL_WebAPI.Models;
namespace BusinessAPISQL.Controllers
{
    [RoutePrefix("api/search")]
    public class searchController : ApiController
    {
        [Route("{searchText}")]
        [HttpGet]
        public Account Search(string searchText)
        {

            RestClient restClient = new RestClient("https://localhost:44376/");

            RestRequest restRequest = new RestRequest("api/Search/{id}", Method.Get);
            restRequest.AddUrlSegment("id", searchText);
            RestResponse restResponse = restClient.Execute(restRequest);

            Account AccDetails = JsonConvert.DeserializeObject<Account>(restResponse.Content);
            
            return AccDetails;


        }



    }
}
