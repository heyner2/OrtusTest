using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DigicelApps.Models.DTOs
{
    public class ApplicationCreationDto
    {
        [Required(ErrorMessage ="Este campo es mandatorio")]
        [Display(Name ="Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo es mandatorio")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo es mandatorio")]
        [Display(Name = "Departamento")]
        public string Deparment { get; set; }

        [Required(ErrorMessage = "Este campo es mandatorio")]
        [Display(Name = "Categoria")]
        public int Category { get; set; }
        
        [Display(Name = "Encargado")]
        public string Owner { get; set; }

    }
}
