using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital.BusinessLayer
{
    internal class Patient
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Diagnosis { get; set; }
        public string Complain { get; set; }//жалоба
        public string Treatment { get; set; }
        public Patient(string name, int age, int weight, string gender, string complain)
        {
            Name = name;
            Gender = gender;
            Age = age;
            Weight = weight;
            Complain = complain;
        }

    }
}
