using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirUdC.GUI.Models.Parameters
{
    public class Property_Model
    {
        [DisplayName("Propiedad")]
        public long Id { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "La dirección es requerida")]
        [StringLength(200, ErrorMessage = "La dirección debe tener entre 1 y 200 caracteres", MinimumLength = 1)]
        public string PropertyAddress { get; set; }

        [DisplayName("Cantidad de Personas")]
        [Required(ErrorMessage = "La cantidad de personas es requerida")]
        [Range(1, 100, ErrorMessage = "La cantidad de personas debe estar entre 1 y 100")]
        public int CustomerAmount { get; set; }

        [DisplayName("Precio")]
        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.01, 1000000, ErrorMessage = "El precio debe estar entre 0.01 y 1,000,000")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El precio debe tener hasta dos decimales")]
        public decimal Price { get; set; }

        [DisplayName("Latitud")]
        [Required(ErrorMessage = "La latitud es requerida")]
        [StringLength(20, ErrorMessage = "La latitud debe tener entre 1 y 20 caracteres", MinimumLength = 1)]
        public string Latitude { get; set; }

        [DisplayName("Longitud")]
        [Required(ErrorMessage = "La longitud es requerida")]
        [StringLength(20, ErrorMessage = "La longitud debe tener entre 1 y 20 caracteres", MinimumLength = 1)]
        public string Longitude { get; set; }

        [DisplayName("Información Check In")]
        [Required(ErrorMessage = "El Check In es requerido")]
        [StringLength(200, ErrorMessage = "El Check In debe tener entre 1 y 200 caracteres", MinimumLength = 1)]
        public string CheckinData { get; set; }

        [DisplayName("Información Check Out")]
        [Required(ErrorMessage = "El Check Out es requerido")]
        [StringLength(200, ErrorMessage = "El Check Out debe tener entre 1 y 200 caracteres", MinimumLength = 1)]
        public string CheckoutData { get; set; }

        [DisplayName("Detalles")]
        public string Details { get; set; }

        [DisplayName("Mascotas")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(typeof(bool), "false", "true", ErrorMessage = "Por favor, escribe un valor válido")]
        public bool Pets { get; set; }

        [DisplayName("Congelador")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(typeof(bool), "false", "true", ErrorMessage = "Por favor, escribe un valor válido")]
        public bool Freezer { get; set; }

        [DisplayName("Servicio de lavandería")]
        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(typeof(bool), "false", "true", ErrorMessage = "Por favor, escribe un valor válido")]
        public bool LaundryService { get; set; }

        [Required]
        public CityModel City { get; set; }
        public IEnumerable<CityModel> CityList { get; set; }

        [Required]
        public PropertyOwnerModel PropertyOwner { get; set; }
        public IEnumerable<PropertyOwnerModel> PropertyOwnerList { get; set; }
    }
}