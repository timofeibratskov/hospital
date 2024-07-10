using hospital.BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital.DataAccessLayer
{
    internal class FileWorker
    {
        public void WriteInCard(Patient patient, string text)
        {
            string filepath = $"C:\\Users\\User\\source\\repos\\hospital\\hospital\\DataAccessLayer\\Cards{patient.Name}.txt";

            using (StreamWriter writer = File.AppendText(filepath))
            {
                writer.WriteLine(text);
            }
        }
        public void ReadCard(Patient patient)
        {
            string filepath = $"C:\\Users\\User\\source\\repos\\hospital\\hospital\\DataAccessLayer\\Cards{patient.Name}.txt";

            using (StreamReader reader = new StreamReader(filepath))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
}
