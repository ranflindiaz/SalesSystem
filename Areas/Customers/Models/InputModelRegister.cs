using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem.Areas.Customers.Models
{
    public class InputModelRegister
    {
        [Required(ErrorMessage = "El campo Nid es obligatorio.")]
        public string Nid { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        public string LastName { get; set; }
        
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Direccion es obligatorio.")]
        public string Direction { get; set; }
        [Required(ErrorMessage = "El campo Telefono es obligatorio.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "El formato telefono ingresado no es válido.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "El campo Fecha es obligatorio.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public bool Credit { get; set; }
        public byte[] Image { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
    }
}
