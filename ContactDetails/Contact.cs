using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDetails
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public string PinNumber { get; set; }

        public Contact(string contact) 
        {
            var contactDetail = contact.Split(';');
            this.FirstName = contactDetail[0];
            this.LastName = contactDetail[1];
            this.State = contactDetail[2];
            this.PinNumber = contactDetail[3];
        }

        public override string ToString()
        {
            return $"{FirstName};{LastName};{State};{PinNumber}";
        }
    }
}
