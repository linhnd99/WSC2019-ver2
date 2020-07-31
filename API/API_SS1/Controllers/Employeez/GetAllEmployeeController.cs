using API_SS1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_SS1.Controllers.Employee
{
    public class GetAllEmployeeController : ApiController
    {
        [HttpPost]
        public dynamic Post()
        {
            WSC2019_SS1Entities db = new WSC2019_SS1Entities();
            return db.Employees.Select(x => new { 
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Phone = x.Phone
            });
        }
    }
}
