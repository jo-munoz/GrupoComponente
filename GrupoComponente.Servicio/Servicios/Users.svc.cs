namespace GrupoComponente.Servicio.Servicios
{
    using GrupoComponente.Servicio.Models.BindingModels;
    using GrupoComponente.Servicio.Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects;
    using System.Linq;

    public class Users : IUsers
    {
        public ObjectParameter cMensaje = new ObjectParameter("cMensaje", typeof(String));

        public IEnumerable<UsersIndexViewModel> getUsers()
        {
            BL.Users users = new BL.Users();
            var resultado = users.GetUsers();

            var listado = resultado.Select(x => new UsersIndexViewModel
            {
                id = x.id,
                Name = x.Name == null ? " " : x.Name,
                Date = x.Date == null ? " " : x.Date.Value.ToString("dd-MM-yyyy"),
                Sex = x.Sex == null ? " "  : x.Sex == "F" ? "Femenino" : "Masculino"
            });

            return listado;
        }

        public UsersEditBindingModel getUserById(int? id)
        {
            BL.Users users = new BL.Users();
            var resultado = users.GetUsers(id).FirstOrDefault();

            var listado = new UsersEditBindingModel
            {
                id = resultado.id,
                Name = resultado.Name,
                Date = resultado.Date.Value.ToString("yyyy-MM-dd"),
                Sex = resultado.Sex == null ? " " : resultado.Sex
            };

            return listado;
        }

        public string CreateUser(UsersCreateBindingModel model)
        {
            try
            {
                using (DAL.Models.anubisEntities obDatos = new DAL.Models.anubisEntities())
                {
                    var resultado = obDatos.spUsuariosCRUD(-1, model.Name, model.Date, model.Sex, 1, cMensaje);

                    return resultado.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string EditUser(UsersEditBindingModel model)
        {
            try
            {
                using (DAL.Models.anubisEntities obDatos = new DAL.Models.anubisEntities())
                {
                    var resultado = obDatos.spUsuariosCRUD(model.id, model.Name, Convert.ToDateTime(model.Date), model.Sex, 2, cMensaje);

                    return resultado.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}