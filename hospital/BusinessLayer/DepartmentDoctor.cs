using hospital.DataAccessLayer;
using hospital.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital.BusinessLayer
{
    class DepartmentDoctor : Doctor
    {


        public DepartmentDoctor(string name) : base(name) { }
        public void GetTreatmentAndDiagnosis(Patient patient, DepartmentDoctor d)
        {
            string filepath = $"C:\\Users\\User\\source\\repos\\hospital\\hospital\\DataAccessLayer\\Cards{patient.Name}.txt";
            Console.WriteLine("Диагноз: ");
            patient.Diagnosis = Console.ReadLine();
            Console.WriteLine("Лечение: ");
            patient.Treatment = Console.ReadLine();
            WriteInCard(patient, $"Диагноз:{patient.Diagnosis} Лечение: {patient.Treatment}, прописал: {d.Name}");
        }
        public void ReleaseThePatientFromDepartment(Patient patient, Department department, DepartmentDoctor d)
        {
            WriteInCard(patient, $"вылечен и выписан из {department.Label},подписано {d.Name}");
            department.Patients.Remove(patient);
        }
    }
}
