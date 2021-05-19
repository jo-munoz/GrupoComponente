namespace GrupoComponente.Servicio.Models.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    #region UsersIndexViewModel
    public class UsersIndexViewModel
    {
        public int id { get; set; }

        [Display(Name = "Nombre Completo")]
        public string Name { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        public string Date { get; set; }

        [Display(Name = "Sexo")]
        public string Sex { get; set; }
    }
    #endregion

    #region UsersDetailsViewModel
    public class UsersDetailsViewModel
    {
        public int id { get; set; }

        [Display(Name = "Nombre Completo")]
        public string Name { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        public DateTime Date { get; set; }

        [Display(Name = "Sexo")]
        public string Sex { get; set; }
    }
    #endregion
}