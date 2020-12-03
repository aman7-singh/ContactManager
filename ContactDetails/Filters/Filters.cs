using ContactManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDetails.Filters
{
    internal class Filters
    {
        ContactStore _contactStore;
        public Filters(ContactStore contactStore) 
        {
            _contactStore = contactStore;
        }
        public List<Contact> ContactFieldFilter(string field, string fieldInfo)
        {
            switch (field)
            {
                case "fn":
                    return _contactStore.GetAllContacts().Where(c => c.FirstName == fieldInfo).ToList();
                    break;
                case "ln":
                    return _contactStore.GetAllContacts().Where(c => c.LastName == fieldInfo).ToList();
                    break;
                case "st":
                    return _contactStore.GetAllContacts().Where(c => c.State == fieldInfo).ToList();
                    break;
                case "pin":
                    return _contactStore.GetAllContacts().Where(c => c.PinNumber == fieldInfo).ToList();
                    break;
                default:
                    return new List<Contact> { new Contact($"Invalid field name: {field}")};
                    break;
            }
        }
        public void Option() 
        {
            throw new NotImplementedException();
        }
    }
}
