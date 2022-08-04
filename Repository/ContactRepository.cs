using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleContatos.Models;
using ControleContatos.Data;

namespace ControleContatos.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;
        
        public ContactRepository(Context context)
        {
            _context = context;
        }

        public List<ContactModel> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public ContactModel Add(ContactModel contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public ContactModel GetOne(int id)
        {
            ContactModel contact = _context.Contacts.FirstOrDefault(x => x.Id == id);

            return contact;
        }

        public ContactModel Edit(ContactModel contact)
        {
            ContactModel dbContact = GetOne(contact.Id);
            if(dbContact == null) throw new Exception("Error changing contact!");

            dbContact.Name = contact.Name;
            dbContact.Email = contact.Email;
            dbContact.Phone = contact.Phone;
            _context.Update(dbContact);
            _context.SaveChanges();

            return dbContact;
        }

        public bool ConfirmDelete(int id)
        {
            ContactModel dbContact = GetOne(id);
            if(dbContact == null) throw new Exception("Error deleting contact!");

            _context.Contacts.Remove(dbContact);
            _context.SaveChanges();
            
            return true;
        }
    }
}