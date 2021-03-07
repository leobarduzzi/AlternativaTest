
using System.Collections.Generic;
using System.Linq;
using AlternativaTest.Data;
using AlternativaTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AlternativaTest.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDataContext _db;

        public CategoryRepository(AppDataContext db){
            this._db = db;
        }

        public List<Category> Get()
        {
            return _db.Categories.AsNoTracking().ToList();
        }

        public Category GetById(int id)
        {
            return _db.Categories.Find(id);
        }

        public void Add(Category category)
        {
            _db.Categories.Add(category);
        }

        public void Update(Category category)
        {
            _db.Entry<Category>(category).State = EntityState.Modified;
            _db.SaveChanges();
        }
        
        public void Delete(int id)
        {
            var category = GetById(id);
            _db.Categories.Remove(category);
        }

        public bool HasProducts(int id)
        {
            var productId = _db.Products
                .Where(p => p.CategoryId == id)
                .AsNoTracking()
                .Select(p => p.Id)
                .First();
            return productId > 0;
        }
    }
}