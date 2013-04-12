using System.Web.Mvc;

namespace FirstAsp.NetMVCApp.Controllers
{
    using System;
    using System.Linq;

    using FirstAsp.NetMVCApp.Models;

    public class SecondController : Controller
    {
        private IToDoRepository _repo = new ToDoMemoryRepository();

        //
        // GET: /First/

        public String Index()
        {
            return "Benfica";
        }

        public String Other()
        {
            return "O maior";
        }


        public ActionResult TodoJson()
        {
            return new JsonResult
                {
                    Data = _repo.GetAll().ToArray(),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
        }


        public ActionResult TodosList()
        {
            return View("TodosList1", _repo.GetAll());
        }
    }
}
