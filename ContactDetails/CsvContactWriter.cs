using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDetails
{
    public static class CsvContactWriter
    {
        public static void WriteContactToCsv(string path, List<Contact> contact)
        {
            var contactStrings = new List<string>();
            contact.ForEach(c => contactStrings.Add(c.ToString()));
            File.AppendAllLines(path, contactStrings);
        }
    }
}
