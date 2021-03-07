
using System;
using System.Collections.Generic;
using AlternativaTest.Models;

namespace AlternativaTest
{
    public interface IProductRepository
    {
        List<Product> Get();
        Product GetById(int id);
        void Add(Product product); 
        void Update(Product Product);
        void Delete(int id);
    }
}