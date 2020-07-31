using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_SS3.Controllers
{
    public class ScheduleModelController : ApiController
    {
        [HttpPost]
        public dynamic post()
        {
            WSC2019_SS3Entities db = new WSC2019_SS3Entities();
            return db.PMScheduleModels.Select(x => new
            {
                ID = x.ID,
                Name = x.Name,
                ScheduleTypeID = x.PMScheduleTypeID,
                ScheduleTypeName = x.PMScheduleType.Name
            });
        }
    }
}
