using API_SS1.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace API_SS1.Controllers
{
    public class GetAllDepartmentController : ApiController
    {
        [HttpPost]
        public dynamic Post()
        {
            WSC2019_SS1Entities db = new WSC2019_SS1Entities();
            return db.Departments.Select(x=> new { ID=x.ID, Name=x.Name});
        }
    }
}