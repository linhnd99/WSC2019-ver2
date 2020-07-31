using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_SS3.Controllers
{
    public class PMTaskController : ApiController
    {
        [HttpPost]
        public dynamic post()
        {
            WSC2019_SS3Entities db = new WSC2019_SS3Entities();
            return db.PMTasks.Select(x => new {
                ID = x.ID,
                AssetID = x.AssetID,
                AssetName = x.Asset.AssetName,
                AssetSN = x.Asset.AssetSN,
                TaskID = x.TaskID,
                TaskName = x.Task.Name,
                PMScheduleTypeID = x.PMScheduleTypeID,
                PMScheduleTypeName = x.PMScheduleType.Name,
                ScheduleDate = x.ScheduleDate,
                ScheduleKilometer = x.ScheduleKilometer,
                TaskDone = x.TaskDone
            });
        }
    }
}
