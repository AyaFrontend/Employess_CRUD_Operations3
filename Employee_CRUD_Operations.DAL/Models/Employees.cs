using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_CRUD_Operations.DAL.Models
{
    public class Employees : BaseEntity
    {
        public string Name { set; get; }

        public DateTime DateOfBirth { set; get; }

        public string Mobile { set; get; }

        [Email]
        public string Email { set; get; }

        public DateTime HireDate { set; get; }

        [Range(0,9999999999999999.99)]
        public decimal Salary { set; get; }

        public string ProfileImage { set; get; }

        public DateTime CreatedDate { set; get; } = DateTime.Now;

        public DateTime ModifiedDate { set; get; }

        public string DepartmentId { set; get; }

        public virtual Departments Department { set; get; }

        public string CreatedBy { set; get; }

        public virtual Users UserWhoCreated { set; get; }

        public string ModifiedBy { set; get; }

        public virtual Users UserWhoModified { set; get; }

    }
}
