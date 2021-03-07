
using System.Collections.Generic;
using System.Linq;
using AlternativaTest.Data;
using AlternativaTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AlternativaTest.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AppDataContext _db;

        public ProductRepository(AppDataContext db){
            this._db = db;
        }

        public List<Product> Get()
        {
            return _db.Products.AsNoTracking().ToList();
        }

        public Product GetById(int id)
        {
            return _db.Products.Find(id);
        }

        public void Add(Product product)
        {
            _db.Products.Add(product);
        }

        public void Update(Product product)
        {
            _db.Entry<Product>(product).State = EntityState.Modified;
            _db.SaveChanges();
        }
        
        public void Delete(int id)
        {
            var product = GetById(id);
            _db.Products.Remove(product);
        }
    }
}