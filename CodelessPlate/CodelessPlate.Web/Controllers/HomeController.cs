using System.Web.Mvc;
using CodelessPlate.Data;
using CodelessPlate.Models;

namespace CodelessPlate.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new DummyModel()
            {
                Description = "This string is stored in RavenDB"
            };

            var modelId = RavenInstance.Current.Store(model);

            var modelFromDb = RavenInstance.Current.Load<DummyModel>(modelId);

            return View(modelFromDb);
        }
    }
}