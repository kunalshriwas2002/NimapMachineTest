using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace MVCMachineTest.Models
{
    public class ProductListDBContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public List<ProductList> GetProductsList()
        {
            List<ProductList> ProductLists = new List<ProductList>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetBothTableData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProductList prod = new ProductList();
                prod.ProductId = Convert.ToInt32(dr.GetValue(0).ToString());
                prod.ProductName = dr.GetValue(1).ToString();
                prod.CategoryId = Convert.ToInt32(dr.GetValue(2).ToString());
                prod.CategoryName = dr.GetValue(3).ToString();
                ProductLists.Add(prod);
            }
            con.Close();
            return ProductLists;
        }

       
    }
}