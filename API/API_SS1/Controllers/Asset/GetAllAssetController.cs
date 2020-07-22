using API_SS1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace API_SS1.Controllers.Asset
{
    public class GetAllAssetController : ApiController
    {
        [HttpPost]
        public dynamic Post()
        {
            WSC2019_SS1Entities db = new WSC2019_SS1Entities();
            return db.Assets.Select(x => new
            {
                ID = x.ID,
                AssetSN = x.AssetSN,
                AssetName = x.AssetName,
                DepartmentLocationID = x.DepartmentLocationID,
                EmployeeID = x.EmployeeID,
                AssetGroupID = x.AssetGroupID,
                Description = x.Description,
                WarrantyDate = x.WarrantyDate,
                DepartmentID = x.DepartmentLocation.DepartmentID,
                DepartmentName = x.DepartmentLocation.Department.Name
            }) ;
        }
    }
}
