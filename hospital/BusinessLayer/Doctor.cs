using hospital.DataAccessLayer;
using hospital.BusinessLayer;
using hospital.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace hospital.BusinessLayer
{
    internal class Doctor : FileWorker
    {
        public string Name { get; set; }
        public Doctor(string name)
        {
            Name = name;
        }
        public void CheckUpPatient(Patient patient)
        {
            Console.WriteLine($"Пациент {patient.Name} был осмотрен {Name}");
            GiveCard(patient);
        }
        public void GiveCard(Patient patient)
        {
            string filepath = $"C:\\Users\\User\\source\\repos\\hospital\\hospital\\DataAccessLayer\\Cards{patient.Name}.txt";
            File.Create(filepath).Close();
            Console.WriteLine($"карточка на имя {patient.Name} успешно создана.");
            Default(patient);

        }
        public void Default(Patient patient)
        {
            string filepath = $"C:\\Users\\User\\source\\repos\\hospital\\hospital\\DataAccessLayer\\Cards{patient.Name}.txt";
            using (StreamWriter writer = File.AppendText(filepath))

            {
                writer.WriteLine($"name: {patient.Name}, gender: {patient.Gender}, Age: {patient.Age}, Complain: {patient.Complain}");
            }
        }
        public void SendToTheDepartament(Patient patient, Department department)
        {
            department.AddPatient(patient);
        }
        /*public void WriteInCard(Patient patient, string text)
        {
            string filepath = $"C:\\Users\\User\\source\\repos\\HOSP\\HOSP\\DataAccessLayer\\PatientsCards\\{patient.Name}.txt";

            using (StreamWriter writer = File.AppendText(filepath))

            {
                writer.WriteLine(text);
            }
        }
        public void ReadCard(Patient patient)
        {
            string filepath = $"C:\\Users\\User\\source\\repos\\HOSP\\HOSP\\DataAccessLayer\\PatientsCards\\{patient.Name}.txt";

            using (StreamReader reader = new StreamReader(filepath))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }*/
    }
}
