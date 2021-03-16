using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProductionMonitoringV1.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The Username Is Required")]
        [Display(Name = "User Name")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Password Is Required")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string Password { get; set; }
    }
}