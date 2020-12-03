using ContactDetails;
using ContactDetails.Actions;
using ContactManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactManagerApp.Commands
{
    internal class Commands:ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ContactStore _contactStore;
        Actions _actions;

        public Commands(ContactStore contactStore, Actions actions) 
        {
            _contactStore = contactStore;
            _actions = actions;
        }
        public bool Add(string contactStr) 
        {
            return _actions.Add(contactStr);
        }
        public  bool Remove(string firstName) 
        {
            return _actions.Remove(firstName);
        }
        public List<string> Find(string field, string fieldInfo) 
        {
            var contacts =_actions.Find(field, fieldInfo);
            return contacts;
        }
        public List<string> List() 
        {
            return _actions.List().ToList();
        }
        public bool Load() 
        {
            return _actions.Load();
        }
        public bool Save() 
        {
            return _actions.Save();
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            this.Execute(parameter);
        }
    }
}
