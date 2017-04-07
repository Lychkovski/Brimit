using System;
using System.Collections.Generic;
using Contacts.Domain;

namespace Contacts.Domain.Interfaces
{
    public interface IContactRepository : IDisposable
    {
        IEnumerable<Contact> GetContacts();
        void AddContact(Contact contact);
        void Save();
    }
}
