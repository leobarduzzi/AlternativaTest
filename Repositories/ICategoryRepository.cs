
using System;
using System.Collections.Generic;
using AlternativaTest.Models;

namespace AlternativaTest
{
    public interface ICategoryRepository 
    {
        List<Category> Get();
        Category GetById(int id);
        void Add(Category category); 
        void Update(Category category);
        void Delete(int id);
        bool HasProducts(int id);
    }
}