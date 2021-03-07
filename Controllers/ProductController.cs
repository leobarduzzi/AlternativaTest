
using System.Collections.Generic;
using AlternativaTest.Models;
using AlternativaTest.Repositories;
using AlternativaTest.UoW;
using AlternativaTest.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlternativaTest.Controllers
{
    public class ProductController
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _uow;

        public ProductController(IProductRepository repository, IUnitOfWork uow)
        {
            this._repository = repository;
            this._uow = uow;
        }

        [Route("v1/products")]
        [HttpGet]
        public ResultViewModel Get()
        {
            return new ResultViewModel
                {
                    Success = true,
                    Message = "",
                    Data = _repository.Get()
                };
        }

        [Route("v1/products/{id}")]
        [HttpGet]
        public ResultViewModel GetById(int id)
        {
            return new ResultViewModel
                {
                    Success = true,
                    Message = "",
                    Data = _repository.GetById(id)
                };
        }

        [Route("v1/products/")]
        [HttpPost]
        public ResultViewModel Save([FromBody]ProductViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o produto",
                    Data = model.Notifications
                };
            var product = new Product();
            product.Name = model.Name;
            product.Description = model.Description;
            product.Value = model.Value;
            product.Brand = model.Brand;
            product.CategoryId = model.CategoryId;

            _repository.Add(product);
            _uow.Commit();

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto cadastrado com sucesso!",
                Data = product
            };

            
        }

        [Route("v1/products")]
        [HttpPut]
        public ResultViewModel Update([FromBody]ProductViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi alterar cadastrar o produto",
                    Data = model.Notifications
                };
            var product = _repository.GetById(model.Id);
            product.Name = model.Name;
            product.Description = model.Description;
            product.Value = model.Value;
            product.Brand = model.Brand;
            product.CategoryId = model.CategoryId;

            _repository.Update(product);
            _uow.Commit();
            
            return new ResultViewModel
            {
                Success = true,
                Message = "Produto alterado com sucesso!",
                Data = product
            };
        }   
    
        [Route("v1/products/{id}")]
        [HttpDelete]
        public ResultViewModel Delete(int id)
        {
            _repository.Delete(id);
            _uow.Commit();
            return new ResultViewModel
            {
                Success = true,
                Message = "Produto deletado com sucesso!",
                Data = null
            };
        }
    
    }
}