using GrupoComponente.Servicio.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoComponente.Controllers
{
    public class UsuariosController : Controller
    {
        [HttpGet]
        public ActionResult ConsultaUsuario()
        {
            ServiceReferenceUsers.UsersClient users = new ServiceReferenceUsers.UsersClient();
            var model = users.getUsers();

            return View(model);
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

            if (resultado.Equals("Se realizo proceso con exito"))
            {
                TempData["ColorAlerta"] = "success";
                TempData["Message"] = resultado;
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

        public enum Genero
        {
            Femenino,
            Masculino
        }
    }
}