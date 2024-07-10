using hospital.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace hospital.BusinessLayer
{
    class Department
    {
        public string Label { get; set; }
        public DepartmentDoctor DepDoctor { get; set; }
        public List<Patient> Patients { get; set; }
        public List<Nurse> Nurses { get; set; }
        public string DepartmentDoctor { get; internal set; }

        public Department(string label)
        {
            Label = label;
            Patients = new List<Patient>();
            Nurses = new List<Nurse>();
        }
        public void AddPatient(Patient patient)
        {
            Patients.Add(patient);
        }
        public void RemovePatient(Patient patient) { Patients.Remove(patient); }
        public void AddNurse(Nurse nurse)
        {
            Nurses.Add(nurse);
        }
        public void RemoveNurse(Nurse nurse)
        {
            Nurses.Remove(nurse);
        }

    }
}
