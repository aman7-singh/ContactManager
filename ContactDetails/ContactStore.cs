using ContactDetails;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class ContactStore
    {
        static List<Contact> contacts = new List<Contact>();
        public static string Path { get { return System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Contacts.csv"); } }
        public void StoreContacts(Contact contact)
        {
            contacts.Add(contact);
        }
        public List<Contact> GetAllContacts()
        {
            return contacts;
        }
        public List<string> GetAllContactsAsString()
        {
            
            var contactsString = CsvContactReader.GetContactsFromCsv(Path);
            return contactsString.ToList();
        }
        public bool Remove(string firstName) 
        {
            var contact = contacts.Where(c => c.FirstName == firstName).FirstOrDefault();
            contacts.Remove(contact);
            File.Delete(Path);
            foreach (var cont in contacts)
            {
                StoreContacts(cont);
            }
            return true;
        }
        public void LoadAllContacts()
        {
            SaveAllContacts();
            var contactsString = CsvContactReader.GetContactsFromCsv(Path);
            contacts = ConvertToContact(contactsString);
        }
        public void SaveAllContacts()
        {
            CsvContactWriter.WriteContactToCsv(Path, contacts);
            contacts = new List<Contact>();
        }
        private List<Contact> ConvertToContact(string[] contactsString)
        {
            var contacts = new List<Contact>();
            foreach (var contact in contactsString)
            {
                contacts.Add(new Contact(contact));
            }
            return contacts;
        }
    }
}
