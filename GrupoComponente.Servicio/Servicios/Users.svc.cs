namespace GrupoComponente.Servicio.Servicios
{
    using GrupoComponente.Servicio.Models.BindingModels;
    using GrupoComponente.Servicio.Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Users : IUsers
    {
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
                Date = (DateTime) resultado.Date,
                Sex = resultado.Sex == null ? " " : resultado.Sex
            };

            return listado;
        }

        public string CreateUser(UsersCreateBindingModel model)
        {
            BL.Users user = new BL.Users();

            return user.CreateUser(model);
        }

        public string EditUser(UsersEditBindingModel model)
        {
            BL.Users user = new BL.Users();

            return user.EditUser(model);
        }
    }
}