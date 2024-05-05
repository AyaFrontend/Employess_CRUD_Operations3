using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_CRUD_Operations.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [Email]
        public string Email { set; get; }

        [Required]
        public string Password { set; get; }
    }
}
