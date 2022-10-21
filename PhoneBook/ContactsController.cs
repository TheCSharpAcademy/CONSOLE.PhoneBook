using PhoneBook.Models;
using PhoneBook.Models.DTOs;

namespace PhoneBook;

internal class ContactsController
{
    internal void ViewCategories()
    {
        using (var db = new DataContext())
        {
            var categories = db.Categories
            .OrderBy(b => b.Name)
            .ToList();

            List<CategoryToView> categoriesToView = new();

            foreach (var c in categories)
            {
                categoriesToView.Add(new CategoryToView
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name
                });
            }

            if (!categoriesToView.Any())
            {
                Console.Clear();
                Console.WriteLine("There are no categories to view."); 
            } 
            else
            {
                TableVisualisationEngine.ShowTable(categoriesToView, "Categories");
            }
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

    internal List<Contact> ViewContacts()
    {
        using (var db = new DataContext())
        {
            var categories = db.Categories.ToList();

            var contacts = db.Contacts
            .OrderBy(b => b.LastName)
            .ToList();

            if (!contacts.Any())
            {
                Console.Clear();
                Console.WriteLine("There are no contacts to view.");
            }
            else
            {
                var contactsToView = contacts.Select(x => new ContactToView
                {
                    ContactId = x.ContactId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Number = x.Number,
                    Category = categories.Single(y => y.CategoryId == x.CategoryId ).Name
                }).ToList();

                TableVisualisationEngine.ShowTable(contactsToView, "Contacts");
            }

            return contacts;
        }
    }

    internal void ViewContactsByCategoryId(int id)
    {
        using (var db = new DataContext())
        {
            var categories = db.Categories.ToList();

            var contacts = db.Contacts
            .Where(c => c.CategoryId == id)
            .OrderBy(b => b.LastName)
            .Select(x => new ContactToView
            {
                ContactId = x.ContactId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Number = x.Number,
                Category = categories.Single(y => y.CategoryId == x.CategoryId).Name
            })
            .ToList();

            var categoryName = categories.Single(c => c.CategoryId == id).Name;

            TableVisualisationEngine.ShowTable(contacts, categoryName);
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
