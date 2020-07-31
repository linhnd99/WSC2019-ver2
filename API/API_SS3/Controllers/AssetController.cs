using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_SS3.Controllers
{
    public class AssetController : ApiController
    {
        [HttpPost]
        public dynamic post()
        {
            WSC2019_SS3Entities db = new WSC2019_SS3Entities();
            return db.Assets.Select(x => new {
                ID = x.ID,
                AssetSN = x.AssetSN,
                AssetName = x.AssetName,
                Description = x.Description,
                WarrantyDate = x.WarrantyDate
            });
        }
    }
}
