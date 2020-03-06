using Microsoft.AspNetCore.Mvc.Rendering;
using MyFirstWebApp.ViewModels.Home.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.ViewModels.Home
{
    public class TestInputModel
    {
        [Display(Name = "Име")]
        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Адрес")]
        [Required]
        //TODO CUSTOM ATTRIBUTE FOR ADDRESS !!!
        public string Address { get; set; }


        [Display(Name = "Години")]
        [Required(ErrorMessage = @"Полето ""години"" е задължително!")]
        [Range(1, 300, ErrorMessage = "Годините трябва да бъдат между 1 и 300 !")]
        public int Age { get; set; }

        [Display(Name = "Дата на раждане")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Пол")]
        [Required]
        public Gender Gender { get; set; }

        [Display(Name = "Позиция")]
        [Required]
        public IEnumerable<SelectListItem> Positions { get; set; }
    }
}
