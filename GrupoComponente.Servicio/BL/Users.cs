namespace GrupoComponente.Servicio.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Users
    {
        /// <summary>
        /// CONSULTA TODOS LOS USUARIOS
        /// </summary>
        /// <returns></returns>
        public List<Models.DB.tbUsers> GetUsers()
        {
            try
            {
                using (DAL.Models.anubisEntities obDatos = new DAL.Models.anubisEntities())
                {
                    List<Models.DB.tbUsers> users = new List<Models.DB.tbUsers>();

                    users = (from q in obDatos.tbUsers
                             select new Models.DB.tbUsers
                             {
                                 id = q.id,
                                 Name = q.Name,
                                 Date = q.Date,
                                 Sex = q.Sex
                             }).ToList();

                    return users;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// CONSULTA UN USUARIO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Models.DB.tbUsers> GetUsers(int? id)
        {
            try
            {
                using (DAL.Models.anubisEntities obDatos = new DAL.Models.anubisEntities())
                {
                    List<Models.DB.tbUsers> users = new List<Models.DB.tbUsers>();

                    users = (from q in obDatos.tbUsers
                             where q.id == id
                             select new Models.DB.tbUsers
                             {
                                 id = q.id,
                                 Name = q.Name,
                                 Date = q.Date,
                                 Sex = q.Sex
                             }).ToList();

                    return users;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// CREA UN USUARIO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string CreateUser(Models.BindingModels.UsersCreateBindingModel model)
        {
            try
            {
                using (DAL.Models.anubisEntities obDatos = new DAL.Models.anubisEntities())
                {
                    obDatos.tbUsers.Add(new DAL.Models.tbUsers
                    {
                        Name = model.Name.Trim(),
                        Date = model.Date,
                        Sex = model.Sex == "Femenino" ? "F" : "M"
                    });
                    obDatos.SaveChanges();

                    return "Se realizo proceso con exito";
                }
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// MODIFICA UNA CAJA
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string EditUser(Models.BindingModels.UsersEditBindingModel model)
        {
            try
            {
                using (DAL.Models.anubisEntities obDatos = new DAL.Models.anubisEntities())
                {
                    List<Models.DB.tbUsers> user = new List<Models.DB.tbUsers>();
                    user = GetUsers(model.id);

                    if (user.Count == 0)
                    {
                        return "No existe ningun registro con ese número de código";
                    }
                    else
                    {
                        var usuario = obDatos.tbUsers.FirstOrDefault(x => x.id == model.id);

                        usuario.Name = model.Name.Trim();
                        usuario.Date = Convert.ToDateTime(model.Date);
                        usuario.Sex = model.Sex == "Femenino" ? "F" : "M";
                        obDatos.SaveChanges();

                        return "Se realizo proceso con exito";
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}