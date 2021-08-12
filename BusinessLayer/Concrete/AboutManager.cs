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
    public class AboutManager : IAboutService
    {
        IAboutDAL _aboutdal;

        public AboutManager(IAboutDAL aboutdal)
        {
            _aboutdal = aboutdal;
        }

        public void AboutAdd(About about)
        {
            _aboutdal.Insert(about);
        }

        public void AboutDelete(About about)
        {

            _aboutdal.Update(about);
        }

        public void AboutUpdate(About about)
        {
            _aboutdal.Update(about);
        }

       

        public About GetById(int id)
        {
            return _aboutdal.Get(x => x.AboutId == id);
        }

        public List<About> GetList()
        {
           return  _aboutdal.List();
        }
    }
}
