﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
  public  class HeadingManager : IHeadingService
    {
        IHeadingDAL _headingDAL;
        public HeadingManager(IHeadingDAL headingDAL)
        {
            _headingDAL = headingDAL;
        }
       
        public List<Heading> GetList()
        {
            return _headingDAL.List();
        }

        public Heading GetById(int id)
        {
          return  _headingDAL.Get(x => x.HeadingId == id);
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDAL.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
           
            _headingDAL.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDAL.Update(heading);
        }
    }
}
