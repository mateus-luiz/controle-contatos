using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleContatos.Models;

namespace ControleContatos.Repository
{
    public interface IContactRepository
    {
        List<ContactModel> GetAll();

        ContactModel Add(ContactModel contact);

        ContactModel GetOne(int id);

        ContactModel Edit(ContactModel contact);

        bool ConfirmDelete(int id);
    }
}