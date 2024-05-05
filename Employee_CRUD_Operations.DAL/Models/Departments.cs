using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_CRUD_Operations.DAL.Models
{
    public class Departments : BaseEntity
    {
        public string Name { set; get; }

        public string Description { set; get; }
        public virtual ICollection<Employees> Employees { set; get; } = new HashSet<Employees>();
    }
}
