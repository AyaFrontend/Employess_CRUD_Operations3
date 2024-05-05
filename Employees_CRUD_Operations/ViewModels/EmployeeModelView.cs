using DataAnnotationsExtensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_CRUD_Operations.ViewModels
{
    public class EmployeeModelView
    {
        public string Id { set; get; } = Guid.NewGuid().ToString();

        [Required]
        public string Name { set; get; }

        [Required]
        public DateTime DateOfBirth { set; get; }

        [Required]
        public string Mobile { set; get; }

        [Email]
        public string Email { set; get; }

        [Required]
        public DateTime HireDate { set; get; }

        [Required]
        [Range(0, 9999999999999999.99)]
        public decimal Salary { set; get; }

        [Required]
        public string ProfileImage { set; get; }
        public IFormFile FileImage { set; get; }

        public DateTime CreatedDate { set; get; } = DateTime.Now;

       
        public DateTime ModifiedDate { set; get; } =  DateTime.Now;


        public string DepartmentId { set; get; }

        public string CreatedBy { set; get; }
        public string ModifiedBy { set; get; }

    }
}
