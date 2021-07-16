using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMessageService
    {
        List<Message> GetListInBox();
        List<Message> GetListSendBox();

        List<Message> IsDraft(string sendermail);
        void MessageAdd(Message message);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        Message GetById(int id);

        Message GetDraftDetails(int id);
    }
}
