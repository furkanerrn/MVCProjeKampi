﻿using BusinessLayer.Abstract;
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
    public class RoleManager : IRoleService
    {
        IRoleDAL _roleDal;

        public RoleManager(IRoleDAL roleDal)
        {
            _roleDal = roleDal;
        }

        public List<Role> GetRoles()
        {
          return  _roleDal.List();
        }
    }
}
