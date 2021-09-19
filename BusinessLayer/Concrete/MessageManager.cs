using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
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

        public List<Message> GetListInBox()
        {
            return _messageDAL.List(x=>x.ReceiverMail== "furkan@gmail.com");
        }

        public List<Message> GetListSendBox()
        {
            return _messageDAL.List(x=>x.SenderMail== "furkan@gmail.com");
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
