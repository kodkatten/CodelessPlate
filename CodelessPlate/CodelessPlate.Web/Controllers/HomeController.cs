using System.Web.Mvc;
using CodelessPlate.Data;
using CodelessPlate.Models;

namespace CodelessPlate.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRavenInstance _raven;

        public HomeController(IRavenInstance raven)
        {
            _raven = raven;
        }

        // GET: Home
        public ActionResult Index()
        {
            var model = new DummyModel()
            {
                Description = "This string is stored in RavenDB"
            };

            var modelId = _raven.Store(model);
            var modelFromDb = _raven.Load<DummyModel>(modelId);

            return View(modelFromDb);
        }
    }
}