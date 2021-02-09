using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactsApp.Classes
{
    public class Contact
    {
        //defining the primarykey ID to the class/table contacts
        //definig the atribute primarykey to ID ! and its autoincrement
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }

        //implicit definition of properties in the class contact        
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Phone { get; set; }

        //overriding the return of get method in this class to return the correct data on the listview
        public override string ToString()
        {
            return $"{Id} -Name: {Name} - Phone: {Phone} - Email: {Email}";
        }
    }
}
