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
            ContactModel contact = _context.Contacts.Find(id);

            return contact;
        }

        public ContactModel Edit(ContactModel contact)
        {
            return contact;
        }

        public ContactModel ConfirmDelete(ContactModel contact)
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return contact;
        }
    }
}