
using System.Collections.Generic;
using AlternativaTest.Models;
using AlternativaTest.Repositories;
using AlternativaTest.UoW;
using AlternativaTest.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlternativaTest.Controllers
{
    public class CategoryController
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _uow;

        public CategoryController(ICategoryRepository repository, IUnitOfWork uow)
        {
            this._repository = repository;
            this._uow = uow;
        }

        [Route("v1/categories")]
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

        [Route("v1/categories/{id}")]
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

        [Route("v1/categories/")]
        [HttpPost]
        public ResultViewModel Save([FromBody]CategoryViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar a categoria",
                    Data = model.Notifications
                };
            var category = new Category();
            category.Name = model.Name;
            category.Description = model.Description;

            _repository.Add(category);
            _uow.Commit();

            return new ResultViewModel
            {
                Success = true,
                Message = "Categoria cadastrado com sucesso!",
                Data = category
            };
        }

        [Route("v1/categories")]
        [HttpPut]
        public ResultViewModel Update([FromBody]CategoryViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi alterar cadastrar a categoria",
                    Data = model.Notifications
                };
            var category = _repository.GetById(model.Id);
            category.Name = model.Name;
            category.Description = model.Description;

            _repository.Update(category);
            _uow.Commit();
            
            return new ResultViewModel
            {
                Success = true,
                Message = "Categoria alterada com sucesso!",
                Data = category
            };
        }   
    
        [Route("v1/categories/{id}")]
        [HttpDelete]
        public ResultViewModel Delete(int id)
        {
            if(_repository.HasProducts(id))
                return new ResultViewModel
                {
                    Success = true,
                    Message = "Não é possivel excluir uma categoria que contém produtos!",
                    Data = null
                };
            _repository.Delete(id);
            _uow.Commit();
            return new ResultViewModel
            {
                Success = true,
                Message = "Categoria deletada com sucesso!",
                Data = null
            };
        }
    
    }
}