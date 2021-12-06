using PhoneBook.Models;
using PhoneBook.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    internal class ContactsController
    {
        internal void ViewCategories()
        {
            using (var db = new DataContext())
            {

                var categories = db.Categories
                .OrderBy(b => b.Name)
                .ToList();

                Console.WriteLine(categories.ToString());

                List<CategoryToView> categoriesToView = new();

                foreach (var c in categories)
                {
                    categoriesToView.Add(new CategoryToView
                    {
                        CategoryId = c.CategoryId,
                        Name = c.Name
                    });
                }
                
                TableVisualisationEngine.ShowTable(categoriesToView, "Categories");
            }   
        }

        internal Category GetCategoryById(int id)
        {
            Category category = new();
            using (var db = new DataContext())
            {
                category = db.Categories.FirstOrDefault(c => c.CategoryId != null && c.CategoryId == id);
            }
            return category;
        }

        internal void AddCategory(string categoryName)
        {
            using (var db = new DataContext())
            {
                db.Add(new Category { Name = categoryName });
                db.SaveChanges();
            }

            ViewCategories();
        }

        internal void DeleteCategory(Category category)
        {
            using (var db = new DataContext())
            {
                db.Remove(category);
                db.SaveChanges();
            }

            ViewCategories();
        }

        internal void UpdateCategory(int id, string name)
        {
            using (var db = new DataContext())
            {
                var category = db.Categories.First(c => c.CategoryId == id);

                category.Name = name;

                db.SaveChanges();
            }

            ViewCategories();
        }

        internal void ViewContacts()
        {
            using (var db = new DataContext())
            {

                var contacts = db.Contacts
                .OrderBy(b => b.LastName)
                .ToList();

                Console.WriteLine(contacts.ToString());

                TableVisualisationEngine.ShowTable(contacts, "Contacts");
            }
        }

        internal Contact GetContactById(int id)
        {
            Contact contact = new();
            using (var db = new DataContext())
            {
                contact = db.Contacts.FirstOrDefault(c => c.ContactId != null && c.ContactId == id);
            }
            return contact;
        }

        internal void AddContact(Contact contact)
        {
            using (var db = new DataContext())
            {
                db.Add(contact);
                db.SaveChanges();
            }

            ViewContacts();
        }

        internal void DeleteContact(Contact contact)
        {
            using (var db = new DataContext())
            {
                db.Remove(contact);
                db.SaveChanges();
            }

            ViewContacts();
        }

        internal void UpdateContact(Contact contact)
        {
            using (var db = new DataContext())
            {
                var contactToUpdate = db.Contacts.FirstOrDefault(c => c.ContactId != null && c.ContactId == contact.ContactId);

                contactToUpdate.FirstName = contact.FirstName;
                contactToUpdate.LastName = contact.LastName;
                contactToUpdate.Number = contact.Number;
               
                db.SaveChanges();
            }

            ViewContacts();
        }
    }
}
