using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductionMonitoringV1.Models
{
    public class User
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "The First Name Is Required")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name Is Required")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The Username Is Required")]
        [Display(Name = "User Name")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Email Is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Password Is Required")]
        [DataType(DataType.Password)]
        [StringLength(20)]
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}