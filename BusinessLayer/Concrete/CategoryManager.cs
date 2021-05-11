using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    #region Abstract sınıfı oluşturulmadan önceki metot
    // GenericRepository<Category> repo = new GenericRepository<Category>();
    //public List<Category> GetAllBL()
    //{
    //    return repo.List();
    //}

    //public void CategoryAddBL(Category p)
    //{

    //    if (p.CategoryName == "" || p.CategoryName.Length <= 3 || p.CategoryDescription == "" || p.CategoryName.Length >= 51)
    //    {
    //        //Hata Mesajı
    //    }
    //    else
    //    {
    //        repo.Insert(p);
    //    }

    //}
    #endregion
    {
        ICategoryDAL _categorydal;
        public CategoryManager(ICategoryDAL categorydal)
        {
            _categorydal = categorydal;
        }

        public void CategorUpdate(Category category)
        {
            _categorydal.Update(category);
        }

        public void CategoryAdd(Category category)
        {
            _categorydal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categorydal.Delete(category);
            
        }

        public Category GetById(int id)
        {
            return _categorydal.Get(x => x.CategoryId == id);
        }

        //public void CategoryAddBL(Category category)
        //{
        //    if (category.CategoryName==""||category.CategoryStatus==false)
        //    {
        //        //HAta mesajı
        //    }
        //    else
        //    {
        //        _categorydal.Insert(category);
        //    }
        //}

        public List<Category> GetList()
        {
            return _categorydal.List();
        }
    }
}
