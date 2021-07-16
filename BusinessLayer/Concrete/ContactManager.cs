using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDAL _contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public void AddContact(Contact contact)
        {
            _contactDAL.Insert(contact);
        }

        public void DeleteContact(Contact contact)
        {
            _contactDAL.Delete(contact);
        }

        public List<Contact> GetList()
        {
            return _contactDAL.List();
        }

        public Contact GetById(int id)
        {
            return _contactDAL.Get(x => x.ContactId == id);
        }

        public void UpdateContact(Contact contact)
        {
            _contactDAL.Update(contact);

        }

        public List<Contact> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
