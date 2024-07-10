using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital.BusinessLayer
{
    internal class Hospital
    {
        public List<Department> Departments { get; set; }
        public object Doctor { get; internal set; }

        public Hospital() { Departments = new List<Department>(); }
        public void AddDepartment(Department dep)
        {
            Departments.Add(dep);
        }
        public void RemoveDepartment(Department dep) { Departments.Remove(dep); }

    }
}
