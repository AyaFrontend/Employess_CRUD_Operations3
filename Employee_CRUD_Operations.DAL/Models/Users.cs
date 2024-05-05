using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace Employee_CRUD_Operations.DAL.Models
{
    public class Users : BaseEntity
    {
        public string Name { set; get; }

        [Email]
        public string Email { set; get; }
        
        public string Password { set; get; }

        public virtual ICollection<Employees> Employees { set; get; } = new HashSet<Employees>();
    }
}
