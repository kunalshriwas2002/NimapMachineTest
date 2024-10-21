using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMachineTest.Models
{
    public class ProductDBContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public List<Product> GetProducts()
        {
            List<Product> ProductList = new List<Product>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Product prod = new Product();
                prod.ProductId = Convert.ToInt32(dr.GetValue(0).ToString());
                prod.ProductName = dr.GetValue(1).ToString();
                ProductList.Add(prod);
            }
            con.Close();
            return ProductList;
        }

        public bool AddProduct(Product prod)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spInsertProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@productName", prod.ProductName);
            cmd.Parameters.AddWithValue("@categoryId", prod.CategoryId);
            int a = cmd.ExecuteNonQuery();
            con.Close();
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateProduct(Product prod)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@productId", prod.ProductId);
            cmd.Parameters.AddWithValue("@productName", prod.ProductName);
            cmd.Parameters.AddWithValue("@categoryId", prod.CategoryId);
            int a = cmd.ExecuteNonQuery();
            con.Close();
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteProduct(int id)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spDeleteProductMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@productId", id);
            int a = cmd.ExecuteNonQuery();
            con.Close();
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}