using System;
using System.Collections.Generic;
using System.Linq;
using Contacts.Domain;
using Contacts.Domain.Interfaces;
using System.Data.Entity;

namespace Contacts.Infrastructure.Data
{
    public class ContactRepository : IContactRepository
    {
        private ContactsContext db;
        public ContactRepository()
        {
            this.db = new ContactsContext();
        }
        public IEnumerable<Contact> GetContacts()
        {
            return db.Contacts.ToList();
        }
        public void AddContact(Contact contact)
        {
            db.Contacts.Add(contact);
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
