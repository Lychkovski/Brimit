using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Domain;

namespace Contacts.Infrastructure.Data
{
    public class ContactsContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}
