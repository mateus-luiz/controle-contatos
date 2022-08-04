using System.Diagnostics;
using System;
using System.Collections.Generic;
using ControleContatos.Models;
using ControleContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            List<ContactModel> list = _contactRepository.GetAll();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ContactModel contact = _contactRepository.GetOne(id);
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            ContactModel contact = _contactRepository.GetOne(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            _contactRepository.Add(contact);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveChanges(ContactModel contact){
            _contactRepository.Edit(contact);
            return RedirectToAction("Index");
        }

        public IActionResult ConfirmDelete(int id)
        {
            _contactRepository.ConfirmDelete(id);
            return RedirectToAction("Index");
        }
    }
}