using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDAL _messageDAL;
        Context c = new Context();

        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public void MessageAdd(Message message)
        {
            _messageDAL.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDAL.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDAL.Update(message);
        }

        public Message GetById(int id)
        {
            return _messageDAL.Get(x => x.MessageId==id);
        }

        public List<Message> GetListInBox(string p)
        {
            return _messageDAL.List(x=>x.ReceiverMail== p);
        }




        public List<Message> GetListSendBox(string p)
        {
            return _messageDAL.List(x => x.SenderMail == p);
        }

        public List<Message> IsDraft()
        {
            return _messageDAL.List(x => x.IsTrash == true && x.SenderMail=="admin@gmail.com");
        }

       

        public Message GetDraftDetails(int id)
        {
            return _messageDAL.Get(x => x.MessageId == id &&x.IsTrash==true);
        }

        public List<Message> GetUnreadMessages()
        {
            return _messageDAL.List(x => x.IsRead == false && x.ReceiverMail == "admin@gmail.com");

        }

        public List<Message> GetReadMessages()
        {
            return _messageDAL.List(x => x.IsRead == true && x.ReceiverMail == "admin@gmail.com");

        }
    }
}
