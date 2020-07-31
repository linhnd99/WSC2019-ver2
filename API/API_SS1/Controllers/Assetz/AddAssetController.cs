using API_SS1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace API_SS1.Controllers.Asset
{

    public class AddAssetController : ApiController
    {
        WSC2019_SS1Entities db;
        [HttpPost]
        public dynamic Post([FromBody] object json2)
        {
            try
            {
                Dictionary<string, object> json = JsonConvert.DeserializeObject<Dictionary<string, object>>(json2.ToString());
                db = new WSC2019_SS1Entities();
                Models.Asset asset = new Models.Asset();
                asset.AssetName = json["AssetName"].ToString();
                asset.AssetSN = json["AssetSN"].ToString();
                asset.AssetGroupID = Convert.ToInt32(json["AssetGroupID"]);
                asset.Description = json["Description"].ToString();
                asset.WarrantyDate = Convert.ToInt32(json["WarrantyDate"]);
                asset.EmployeeID = Convert.ToInt32(json["EmployeeID"]);
                int locationid = Convert.ToInt32(json["LocationID"]);
                int departmentid = Convert.ToInt32(json["DepartmentID"]);
                DepartmentLocation dl = db.DepartmentLocations.Where(x => x.LocationID == locationid && x.DepartmentID == departmentid).SingleOrDefault();
                if (dl == null)
                {
                    dl.DepartmentID = departmentid;
                    dl.LocationID = locationid;
                    dl.StartDate = DateTime.Now;
                    db.DepartmentLocations.Add(dl);
                    db.SaveChanges();
                    dl = db.DepartmentLocations.Where(x => x.LocationID == locationid && x.DepartmentID == departmentid).SingleOrDefault();
                }
                asset.DepartmentLocationID = dl.ID;

                db.Assets.Add(asset);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "ok";
        }
    }
}
