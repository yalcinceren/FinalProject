using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{

    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal)
        {
              
            _productDal = productDal;
            
        }
        

        //[ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            logger.Log();
            try
            {

                _productDal.Add(product);

                return new SuccessResult(Messages.ProductAdded);

            }
            catch (Exception exception)
            {

                logger.Log();
            }
            return new ErrorResult();
           
        }

        public IDataResult <List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==13)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

            }
            var a = new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
            return a;
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int Id)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.CategoryId == Id));
        }

        public IDataResult< Product> GetById(int productId)
        {
            return new SuccessDataResult<Product> (_productDal.Get(p => p.ProductId == productId));
        }

        public SuccessDataResult<List<Product>> GetByUnitPrice (decimal min,decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p =>p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        IDataResult<List<Product>> IProductService.GetByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }
    }
        
     
        

       
    
}
