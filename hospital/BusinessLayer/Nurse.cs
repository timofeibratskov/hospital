using hospital.DataAccessLayer;
using hospital.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital.BusinessLayer
{
    internal class Nurse : Doctor
    {

        public Nurse(string name) : base(name)
        {
        }
        public void MakeProdcedures(Patient patient, Nurse nurse)
        {

            WriteInCard(patient, $"cделаны продцедуры больному .Медсестра {nurse.Name}");
        }
    }
}
