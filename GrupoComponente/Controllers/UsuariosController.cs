namespace GrupoComponente.Controllers
{
    using System.Web.Mvc;
    using PagedList;

    public class UsuariosController : Controller
    {
        [HttpGet]
        public ActionResult ConsultaUsuario(int? pageSize, int? page)
        {
            ServiceReferenceUsers.UsersClient users = new ServiceReferenceUsers.UsersClient();
            var model = users.getUsers();

            pageSize = (pageSize ?? 2);
            page = (page ?? 1);
            ViewBag.PageSize = pageSize;

            return View(model.ToPagedList(page.Value, pageSize.Value));
        }

        [HttpGet]
        public ActionResult Usuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Usuario(Servicio.Models.BindingModels.UsersCreateBindingModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            ServiceReferenceUsers.UsersClient users = new ServiceReferenceUsers.UsersClient();
            var resultado = users.CreateUser(model);

            if (resultado.Equals("-1"))
            {
                TempData["ColorAlerta"] = "success";
                TempData["Message"] = "Se realizo proceso con exito";

                return RedirectToAction("ConsultaUsuario");
            }
            else
            {
                ModelState.AddModelError("", resultado.ToString());

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult EditarUsuario(int ? id)
        {
            ServiceReferenceUsers.UsersClient users = new ServiceReferenceUsers.UsersClient();
            var model = users.getUserById(id);

            if (model.Sex.Equals("F"))
                model.Sex = "Femenino";
            else
                model.Sex = "Masculino";

            return View(model);
        }

        [HttpPost]
        public ActionResult EditarUsuario(Servicio.Models.BindingModels.UsersEditBindingModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            ServiceReferenceUsers.UsersClient users = new ServiceReferenceUsers.UsersClient();
            var resultado = users.EditUser(model);

            if (resultado.Equals("-1"))
            {
                TempData["ColorAlerta"] = "success";
                TempData["Message"] = "Se realizo proceso con exito";

                return RedirectToAction("ConsultaUsuario");
            }
            else
            {
                ModelState.AddModelError("", resultado.ToString());

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult EliminarUsuario(int? id)
        {
            ServiceReferenceUsers.UsersClient users = new ServiceReferenceUsers.UsersClient();
            var model = users.getUserById(id);

            if (model.Sex.Equals("F"))
                model.Sex = "Femenino";
            else
                model.Sex = "Masculino";

            return View(model);
        }

        [HttpPost]
        public ActionResult EliminarUsuario(Servicio.Models.BindingModels.UsersEditBindingModel model)
        {
            ServiceReferenceUsers.UsersClient users = new ServiceReferenceUsers.UsersClient();
            var resultado = users.DeleteUser(model.id);

            if (resultado.Equals("Se realizo proceso con exito"))
            {
                TempData["ColorAlerta"] = "success";
                TempData["Message"] = "Se realizo proceso con exito";

                return RedirectToAction("ConsultaUsuario");
            }
            else
            {
                ModelState.AddModelError("", resultado.ToString());

                return View(model);
            }
        }

        public enum Genero
        {
            Femenino,
            Masculino
        }
    }
}