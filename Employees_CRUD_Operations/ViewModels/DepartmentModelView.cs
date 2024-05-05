using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_CRUD_Operations.ViewModels
{
    public class DepartmentModelView
    {
        [Required]
        public string Name { set; get; }

        [Required]
        public string Description { set; get; }
    }
}
