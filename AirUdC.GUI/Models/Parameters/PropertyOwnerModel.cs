using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirUdC.GUI.Models.Parameters
{
    public class PropertyOwnerModel
    {
        [DisplayName("Propietario")]
        public long Id { get; set; }
        [DisplayName("Primer Nombre")]
        [Required(ErrorMessage = "El primer nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre debe tener entre 1 y 50 caracteres", MinimumLength = 1)]
        public string FirstName { get; set; }

        [DisplayName("Apellidos")]
        [Required(ErrorMessage = "Los apellidos son requeridos")]
        [StringLength(50, ErrorMessage = "El campo de apellidos debe tener entre 1 y 50 caracteres", MinimumLength = 1)]
        public string FamilyName { get; set; }

        [DisplayName("Correo Electrónico")]
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        public string Email { get; set; }

        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "El teléfono es requerido")]
        public string Cellphone { get; set; }

        [DisplayName("Foto")]
        public string Photo { get; set; }
    }
}