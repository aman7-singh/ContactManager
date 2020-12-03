using ContactManager;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDetails.Actions
{
    public class Actions
    {
        ContactStore _contactStore;
        public Actions(ContactStore contactStore)
        {
            _contactStore = contactStore;
        }
        public bool Add(string contactStr) 
        {
            try
            {
                var contact = new Contact(contactStr);
                _contactStore.StoreContacts(contact);
                Log.LogInstance.Info($"Added - {contactStr}");
            }
            catch (Exception e)
            {
                Log.LogInstance.Error(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool Remove(string firstname) 
        {
            try 
            {
                _contactStore.Remove(firstname);
                Log.LogInstance.Info($"Removed - {firstname}");
                throw new NotImplementedException();

            }
            catch (Exception e)
            {
                Log.LogInstance.Error(e.StackTrace);
                return false;
            }
            return true;
        }
        public List<string> Find(string field, string fieldInfo)
        {
            List<string> contactstr = new List<string> {"No item in list" };
            try
            {
                Filters.Filters filters = new Filters.Filters(_contactStore);
                var contacts = filters.ContactFieldFilter(field, fieldInfo);
                contacts.ForEach(c => contactstr.Add(c.ToString()));
                Log.LogInstance.Info($"Find - {field}: {fieldInfo}");
            }
            catch (Exception e)
            {
                Log.LogInstance.Error(e.StackTrace);
                return contactstr;
            }
            return contactstr;
        }
        public List<String> List()
        {
            List<string> contacts = new List<string>();
            try
            {
                _contactStore.GetAllContactsAsString().ForEach(c=> contacts.Add(c.ToString()));

                Log.LogInstance.Info($"List --> All contacts");
            }
            catch (Exception e)
            {
                Log.LogInstance.Error(e.StackTrace);
                contacts.Add("No item found.");
                return contacts;
            }
            return contacts;
        }
        public bool Save()
        {
            try
            {
                _contactStore.SaveAllContacts();
            }
            catch (Exception e)
            {
                Log.LogInstance.Error(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool Load()
        {
            try
            {
                _contactStore.LoadAllContacts();
            }
            catch (Exception e)
            {
                Log.LogInstance.Error(e.StackTrace);
                return false;
            }
            return true;
        }
    }
}
