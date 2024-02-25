using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Dappercrud.Models
{
    public class ProductRepository
    {
        private IDbConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        //Add Product     
        public int AddProduct(ProductModel objProduct)
        {
            int intFlag = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ProductName", objProduct.ProductName);
                param.Add("@ProductCode", objProduct.ProductCode);
                param.Add("@ProductQty", objProduct.ProductQty);
                param.Add("@ProductWeight", objProduct.ProductWeight);
                param.Add("@ProductDesc", objProduct.ProductDesc);
                intFlag = _con.Execute("Insert_Product", param, commandType: CommandType.StoredProcedure);
                _con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intFlag;
        }

        //Get All Products 
        public List<ProductModel> GetAllProduct()
        {
            try
            {
                IList<ProductModel> productList = SqlMapper.Query<ProductModel>(_con, "Get_Product").ToList();
                _con.Close();
                return productList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get Product By Product Id 
        public ProductModel GetProductByProductId(int productId)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ProductId", productId);
                ProductModel productList = SqlMapper.Query<ProductModel>(_con, "Get_ProductByProductId", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                _con.Close();
                return productList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Update Product   
        public int UpdateProduct(ProductModel objProduct)
        {
            int intFlag = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ProductId", objProduct.ProductId);
                param.Add("@ProductName", objProduct.ProductName);
                param.Add("@ProductCode", objProduct.ProductCode);
                param.Add("@ProductQty", objProduct.ProductQty);
                param.Add("@ProductWeight", objProduct.ProductWeight);
                param.Add("@ProductDesc", objProduct.ProductDesc);
                intFlag = _con.Execute("Update_Product", param, commandType: CommandType.StoredProcedure);
                _con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intFlag;
        }

        //Delete Product  
        public int DeleteProduct(int productId)
        {
            int intFlag = 0;
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@ProductId", productId);
                intFlag = _con.Execute("Delete_Product", param, commandType: CommandType.StoredProcedure);
                _con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intFlag;
        }
    }
}