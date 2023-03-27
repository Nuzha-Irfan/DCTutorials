using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using System.Xml.Linq;
using API_classes;
using Newtonsoft.Json;
using WebAPI.Models;

namespace WebAPI.Controllers
{
  
    public class SearchController : ApiController
    {

       
        // POST api/<controller>
        public DataIntermed Post( searchData search)
        {   
            List<DataIntermed> list;
            list = AccountList.AllData();
            DataIntermed data= new DataIntermed();

            
            data.acct = 0;
            data.bal = 0;
            data.img = "";
            data.fname = "";
            data.lname = "";
            data.pin = 0;
            
            for (int i=0;i<AccountList.AllData().Count;i++)
            {
                    
                if (String.Equals(list[i].lname, search.searchStr, StringComparison.OrdinalIgnoreCase))
                {   
                    data.acct=list[i].acct;
                    data.bal= list[i].bal;
                    data.img = list[i].img;
                    data.fname=list[i].fname;
                    data.lname=list[i].lname;
                    data.pin=list[i].pin;

                    return data;
                }
            }

            if (data == null)
            {
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.NotImplemented);
                message.Content = new StringContent("The name has not been found");
                throw new HttpResponseException(message);

            }


            return null;


        }   

       
    }
}