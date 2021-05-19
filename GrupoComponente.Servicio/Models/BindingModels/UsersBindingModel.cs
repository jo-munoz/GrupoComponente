namespace GrupoComponente.Servicio.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    #region UsersCreateBindingModel
    public class UsersCreateBindingModel
    {
        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener una longitud maxima de {1} caracteres")]
        public string Name { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime Date { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Sex { get; set; }
    }
    #endregion

    #region UsersEditBindingModel
    public class UsersEditBindingModel
    {
        public int id { get; set; }

        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener una longitud maxima de {1} caracteres")]
        public string Name { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime Date { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Sex { get; set; }
    }
    #endregion
}