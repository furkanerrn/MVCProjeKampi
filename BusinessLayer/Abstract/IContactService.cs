using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetAll();
        void AddContact(Contact contact);
        void DeleteContact(Contact contact);
        void UpdateContact(Contact contact);
        Contact GetById(int id);


    }
}
