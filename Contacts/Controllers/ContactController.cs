using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Contacts.Domain;
using Contacts.Domain.Interfaces;
using Contacts.Services.Interfaces;

namespace Contacts.Controllers
{
    public class ContactController : Controller
    {
        IContactRepository repoContact;
        IBusinessInterface business;

        public ContactController(IContactRepository r, IBusinessInterface b)
        {
            repoContact = r;
            business = b;
        }

        public JsonResult GetContacts()
        {
            var listContacts = repoContact.GetContacts();
            return Json(new { list = listContacts }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddContact(Contact contact)
        {
            repoContact.AddContact(contact);
            repoContact.Save();
            //Additional business logic can be called here: business.AnyMethod();
            return Json(new { status = "Contact save successfully" });
        }

        protected override void Dispose(bool disposing)
        {
            repoContact.Dispose();
            base.Dispose(disposing);
        }
    }
}