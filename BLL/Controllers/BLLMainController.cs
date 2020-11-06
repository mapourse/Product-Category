using AutoMapper;
using BLL.DTO;
using DAL.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controllers
{
    public class BLLMainController
    {
        private Mapper _mppr;
        private DAL.Controllers.DALMainController _dalCntrllr;

        public BLLMainController()
        {
            IConfigurationProvider cfg = new MapperConfiguration(
                c => {
                    c.CreateMap<Category, CategoryDTO>();
                    c.CreateMap<CategoryDTO, Category>();
                    c.CreateMap<Product, ProductDTO>();
                    c.CreateMap<ProductDTO, Product>();
                });

            _mppr = new Mapper(cfg);

            _dalCntrllr = new DAL.Controllers.DALMainController();
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            return _mppr.Map<IEnumerable<CategoryDTO>>(_dalCntrllr.GetCategories());
        }

        public CategoryDTO GetCategorybyId(int catId)
        {
            return _mppr.Map<CategoryDTO>(_dalCntrllr.GetCategorybyId(catId));
        }

        public void InsertorUpdateCategory(CategoryDTO cat)
        {
            _dalCntrllr.InsertorUpdateCategory(_mppr.Map<Category>(cat));
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            return _mppr.Map<IEnumerable<ProductDTO>>(_dalCntrllr.GetProducts());
        }

        public ProductDTO GetProductbyId(int prId)
        {
            return _mppr.Map<ProductDTO>(_dalCntrllr.GetProductbyId(prId));
        }

        public void InsertorUpdateProduct(ProductDTO pr)
        {
            _dalCntrllr.InsertorUpdateProduct(_mppr.Map<Product>(pr));
        }

        public void DeleteProductbyId(int prId)
        {
            _dalCntrllr.DeleteProductbyId(prId);
        }

        public void SaveChanges()
        {
            _dalCntrllr.SaveChanges();
        }
    }
}
