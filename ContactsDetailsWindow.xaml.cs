using DesktopContactsApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for ContactsDetailsWindow.xaml
    /// </summary>
    public partial class ContactsDetailsWindow : Window
    {
        // global variable to receive the contact
        Contact contact;

        //implements the need for pass a contact whenever we implement a new contactsdetailwindow
        public ContactsDetailsWindow(Contact contact)
        {
            InitializeComponent();

            // initialize contact
            this.contact = contact;

            // to populate every textboxat this window:
            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneTextBox.Text = contact.Phone; 
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            // create the conection to database and open it /--- the using statement give the permition to use the dispose to
            // use the sonnection until the end of this litle block of code, and closes the connection automatically
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // verify the table(if don't exists create it) using generics to generate the table contact is called only to create the table
                connection.CreateTable<Contact>();

                // delete the contact into the table Contact
                connection.Delete(contact);
            }

            Close();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            // to update the data present at this window to contacts in the database:
            contact.Name = nameTextBox.Text;
            contact.Email = emailTextBox.Text;
            contact.Phone = phoneTextBox.Text;

            // create the conection to database and open it /--- the using statement give the permition to use the dispose to
            // use the sonnection until the end of this litle block of code, and closes the connection automatically
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // verify the table(if don't exists create it) using generics to generate the table contact is called only to create the table
                connection.CreateTable<Contact>();

                // update the contact into the table Contact
                connection.Update(contact);
            }

            Close();
        }
    }
}
