using hospital.BusinessLayer;
using hospital.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace hospital.BusinessLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("C:\\Users\\User\\source\\repos\\hospital\\hospital\\DataAccessLayer\\data.xml");

            // Retrieve the root element
            XElement hospitalElement = doc.Element("Hospital");

            // Retrieve the department elements
            IEnumerable<XElement> departmentElements = hospitalElement.Elements("Department");

            // Define variables to store the data
            List<string> departmentNames = new List<string>();
            List<string> doctorNames = new List<string>();
            List<string> patientNames = new List<string>();
            List<int> patientAges = new List<int>();
            List<int> patientWeights = new List<int>();
            List<string> patientGenders = new List<string>();
            List<string> patientSymptoms = new List<string>();
            List<string> nurseNames = new List<string>();

            // Iterate over the department elements
            foreach (XElement departmentElement in departmentElements)
            {
                // Retrieve the department name
                string departmentName = (string)departmentElement.Attribute("Label");
                departmentNames.Add(departmentName);

                // Retrieve the department doctor element
                XElement departmentDoctorElement = departmentElement.Element("DepartmentDoctor");
                if (departmentDoctorElement != null)
                {
                    // Retrieve the doctor name
                    string doctorName = (string)departmentDoctorElement.Attribute("Name");
                    doctorNames.Add(doctorName);

                    // Retrieve the patient element
                    XElement patientElement = departmentDoctorElement.Element("Patient");
                    if (patientElement != null)
                    {
                        // Retrieve the patient details
                        string patientName = (string)patientElement.Attribute("Name");
                        int patientAge = (int)patientElement.Attribute("Age");
                        int patientWeight = (int)patientElement.Attribute("Weight");
                        string patientGender = (string)patientElement.Attribute("Gender");
                        string patientSymptom = (string)patientElement.Attribute("Symptoms");

                        // Add the patient details to the lists
                        patientNames.Add(patientName);
                        patientAges.Add(patientAge);
                        patientWeights.Add(patientWeight);
                        patientGenders.Add(patientGender);
                        patientSymptoms.Add(patientSymptom);
                    }
                }

                // Retrieve the nurse element
                XElement nurseElement = departmentElement.Element("Nurse");
                if (nurseElement != null)
                {
                    // Retrieve the nurse name
                    string nurseName = nurseElement.Value;
                    nurseNames.Add(nurseName);
                }
            }
            Hospital hospital = new Hospital();
            Patient patient = new Patient(patientNames[0], patientAges[0], patientWeights[0], patientGenders[0], patientSymptoms[0]);
            Patient patient2 = new Patient(patientNames[1], patientAges[1], patientWeights[1], patientGenders[1], patientSymptoms[1]);
            Doctor doctor = new Doctor("Dr. Lue");
            Department dep = new Department(departmentNames[0]);
            Department dep2 = new Department(departmentNames[1]);
            Department dep3 = new Department(departmentNames[2]);
            DepartmentDoctor depdoc = new DepartmentDoctor(doctorNames[0]);
            DepartmentDoctor depdoc2 = new DepartmentDoctor(doctorNames[1]);
            DepartmentDoctor depdoc3 = new DepartmentDoctor(doctorNames[2]);
            Nurse nurse = new Nurse(nurseNames[0]);
            Nurse nurse2 = new Nurse(nurseNames[1]);
            Nurse nurse3 = new Nurse(nurseNames[2]);
            dep.DepDoctor = depdoc;
            dep2.DepDoctor = depdoc2;
            dep3.DepDoctor = depdoc3;
            dep.AddNurse(nurse);
            dep2.AddNurse(nurse2);
            dep3.AddNurse(nurse3);
            hospital.AddDepartment(dep);
            hospital.AddDepartment(dep2);
            hospital.AddDepartment(dep3);
            doctor.CheckUpPatient(patient);
            foreach (var item in hospital.Departments)
            {
                Console.WriteLine(item.Label);
            }
            doctor.SendToTheDepartament(patient, dep);
            doctor.CheckUpPatient(patient2);
            doctor.SendToTheDepartament(patient2, dep);
            depdoc.GetTreatmentAndDiagnosis(patient, depdoc);
            depdoc.ReadCard(patient);
            dep.AddNurse(nurse);
            nurse.MakeProdcedures(patient, nurse);
            depdoc.ReleaseThePatientFromDepartment(patient, dep, depdoc);
            depdoc.ReadCard(patient);
        }
    }
}
