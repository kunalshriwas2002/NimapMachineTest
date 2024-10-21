using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MVCMachineTest.Models
{
    public class CategoryDBContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public List<Category> GetCategories()
        {
            List<Category> CategoryList=new List<Category>();
            SqlConnection con=new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetCategoryMaster",con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr= cmd.ExecuteReader();
            while (dr.Read())
            {
                Category categ=new Category();
                categ.CategoryId = Convert.ToInt32(dr.GetValue(0).ToString());
                categ.CategoryName = dr.GetValue(1).ToString();
                CategoryList.Add(categ);
            }
            con.Close();
            return CategoryList;

        }

        public bool AddCategory(Category categ)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spInsertCategoryMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@categoryName", categ.CategoryName);
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

        public bool UpdateCategory(Category categ)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateCategoryMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@categoryId", categ.CategoryId);
            cmd.Parameters.AddWithValue("@categoryName", categ.CategoryName);
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

        public bool DeleteCategory(int id)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spDeleteCategoryMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@categoryId", id);
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