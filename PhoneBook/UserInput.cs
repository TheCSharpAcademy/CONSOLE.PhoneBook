using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneBook
{
    internal class UserInput
    {
        ContactsController contactsController = new();
        internal void MainMenu()
        {
            bool closeApp = false;
            while (closeApp == false)
            {
                Console.WriteLine("\n\nMAIN MENU");
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("\nType 0 to Close Application.");
                Console.WriteLine("Type 1 to View Categories");
                Console.WriteLine("Type 2 to Add Category");
                Console.WriteLine("Type 3 to Delete Category");
                Console.WriteLine("Type 4 to Update Category");
                Console.WriteLine("Type 5 to View Contacts");
                Console.WriteLine("Type 6 to Add Contacts");
                Console.WriteLine("Type 7 to Delete Contact");
                Console.WriteLine("Type 8 to Update Contact");

                string commandInput = Console.ReadLine();
                while (string.IsNullOrEmpty(commandInput) || !int.TryParse(commandInput, out _))
                {
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 2.\n");
                    commandInput = Console.ReadLine();
                }

                int command = Convert.ToInt32(commandInput);

                switch (command)
                {
                    case 0:
                        closeApp = true;
                        break;
                    case 1:
                        contactsController.ViewCategories();
                        break;
                    case 2:
                        string categoryName = GetStringInput("Please add category name.");
                        contactsController.AddCategory(categoryName);
                        break;
                    case 3:
                        contactsController.ViewCategories();

                        int categoryId = GetIntegerInput("Please add id of the category you want to delete.");
                        var category = contactsController.GetCategoryById(categoryId);

                        while (category == null)
                        {
                            categoryId = GetIntegerInput($"A category with the id {categoryId} doesn't exist. Try again.");
                        }

                        contactsController.DeleteCategory(category);
                        break;
                    case 4:
                        contactsController.ViewCategories();

                        int id = GetIntegerInput("Please add id of the category you want to update.");
                        var cat = contactsController.GetCategoryById(id);

                        while (cat == null)
                        {
                            id = GetIntegerInput($"A category with the id {id} doesn't exist. Try again.");
                        }

                        string name = GetStringInput("Please enter new name for category.");
                        contactsController.UpdateCategory(id, name);
                        break;

                    case 5:
                        contactsController.ViewContacts();
                        break;
                    case 6:
                        contactsController.ViewCategories();
                        Contact contact = new();
                        contact.CategoryId = GetIntegerInput("Please add categoryId for contact.");
                        contact.FirstName = GetStringInput("Please type first name.");
                        contact.LastName = GetStringInput("Please type last name.");
                        contact.Number = GetPhoneInput("Please type phone number.");

                        contactsController.AddContact(contact);
                        break;

                    case 7:
                        contactsController.ViewContacts();

                        int contactId = GetIntegerInput("Please add id of the category you want to delete.");
                        var contactToDelete = contactsController.GetContactById(contactId);

                        while (contactToDelete == null)
                        {
                            categoryId = GetIntegerInput($"A category with the id {contactId} doesn't exist. Try again.");
                        }

                        contactsController.DeleteContact(contactToDelete);
                        break;
                    case 8:
                        ProcessContactUpdate();
                        
                        break;



                    default:
                        Console.WriteLine("\nInvalid Command. Please type a number from 0 to 6.\n");
                        break;
                }
            }
        }

        private void ProcessContactUpdate()
        {
            contactsController.ViewContacts();

            int conId = GetIntegerInput("Please add id of the category you want to update.");
            var contactToUpdate = contactsController.GetContactById(conId);

            while (contactToUpdate == null)
            {
                conId = GetIntegerInput($"A category with the id {conId} doesn't exist. Try again.");
            }

            contactToUpdate.FirstName = GetUpdateStringInput("Please enter first name or type 0 to keep name");
            contactToUpdate.LastName = GetStringInput("Please enter last name or type 0 to keep name");
            contactToUpdate.Number = GetPhoneInput("Please enter new phone number or type 0 to keep number");
            contactsController.UpdateContact(contactToUpdate);
        }
        private string GetStringInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            while (!Validator.IsStringValid(input))
            {
                Console.WriteLine("\nInvalid input");
                input = Console.ReadLine();
            }

            return input;
        }

        private string GetUpdateStringInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            if (input == "0")
            {
                return;
            }

            while (!Validator.IsUpdateStringValid(input))
            {
                Console.WriteLine("\nInvalid input");
                input = Console.ReadLine();
            }

            return input;
        }

        private string GetPhoneInput(string phone)
        {
            Console.WriteLine(phone);
            string input = Console.ReadLine();

            while (!Validator.IsPhoneValid(input))
            {
                Console.WriteLine("\nInvalid phone");
                input = Console.ReadLine();
            }

            return input;
        }

        private int GetIntegerInput(string message)
        {
            Console.WriteLine(message);
            string idInput = Console.ReadLine();

            while (!Validator.IsIdValid(idInput))
            {
                Console.WriteLine("\nInvalid input");
                idInput = Console.ReadLine();
            }

            return Int32.Parse(idInput);
        }
    }
}
