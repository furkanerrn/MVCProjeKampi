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
      public  class ContentManager : IContentService
      {
        IContentDAL _contentDAL;
        public ContentManager(IContentDAL contentDAL)
        {
            _contentDAL = contentDAL;
        }
        public void ContentAdd(Content content)
        {
            _contentDAL.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            _contentDAL.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDAL.Update(content);
        }

        public Content GetById(int id)
        {
           return _contentDAL.Get(x => x.ContentId == id);
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDAL.List(x => x.HeadingId == id);
        }

        public List<Content> GetList()
        {
            return _contentDAL.List();
        }
    }
}
