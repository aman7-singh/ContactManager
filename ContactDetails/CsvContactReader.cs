using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDetails
{
    public class CsvContactReader
    {
        public static string[] GetContactsFromCsv(string path)
        {
            var contacts = File.ReadAllLines(path);
            return contacts;
        }

    }
}
