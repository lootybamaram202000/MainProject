using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject.DataAccess;
using MainProject.Entities;

namespace MainProject.Core.Business
{
    internal class ProductManager
    {
        private readonly ProductDAL _dal = new ProductDAL();

        public bool InsertProduct(ProductModel product, string userID, string persianDate, DateTime dateValue, int dateDig, out string newID)
        {
            return _dal.InsertProduct(product, userID, persianDate, dateValue, dateDig, out newID);
        }

        public bool UpdateProduct(ProductModel product)
        {
            return _dal.UpdateProduct(product);
        }

        public bool DeleteProduct(string productId)
        {
            return _dal.DeleteProduct(productId);
        }

        public List<ProductModel> GetAllProducts()
        {
            return _dal.GetAllProducts();
        }

        public List<ProductModel> SearchProducts(string keyword)
        {
            return _dal.SearchProducts(keyword);
        }
    }
}
