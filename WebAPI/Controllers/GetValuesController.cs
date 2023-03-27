using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using WebAPI.Models;
using API_classes;
namespace WebAPI.Controllers
{
    
    public class GetValuesController : ApiController
    {
        
        public IEnumerable<DataIntermed> GetData()
        {
            return AccountList.AllData();
           
        }

        public IHttpActionResult GetDataById(int id)
        {
            List<DataIntermed> list = new List<DataIntermed>();
            list = AccountList.AllData();
            DataIntermed data = new DataIntermed();

            for(int i=0;i<=AccountList.AllData().Count;i++)
            {
                if (i==id)
                {
                    data = list[i];
                    return Ok(data);
                }
            }
            if (data == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return NotFound();
        }


    }
}
