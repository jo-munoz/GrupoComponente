namespace GrupoComponente.Servicio.Servicios
{
    using GrupoComponente.Servicio.Models.BindingModels;
    using GrupoComponente.Servicio.Models.ViewModels;
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface IUsers
    {
        [OperationContract]
        IEnumerable<UsersIndexViewModel> getUsers();

        [OperationContract]
        UsersEditBindingModel getUserById(int? id);

        [OperationContract]
        string CreateUser(UsersCreateBindingModel model);

        [OperationContract]
        string EditUser(UsersEditBindingModel model);

        [OperationContract]
        string DeleteUser(int? id);
    }
}