using MVCMachineTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMachineTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            CategoryDBContext db=new CategoryDBContext();
            List<Category> obj=db.GetCategories();
            return View(obj);
        }

        public ActionResult Create()
        {          
            return View();
        }


        [HttpPost]
        public ActionResult Create(Category categ)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    CategoryDBContext context = new CategoryDBContext();
                    bool check = context.AddCategory(categ);
                    if (check == true)
                    {
                        TempData["InsertMessage"] = "<script>alert('Data Has Been Inserted Successfully')</script>";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }

        }


        public ActionResult Edit(int id)
        {
           CategoryDBContext context = new CategoryDBContext();
            var row = context.GetCategories().Find(model => model.CategoryId == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(int id,Category categ)
        {
            if (ModelState.IsValid == true)
            {
               CategoryDBContext context = new CategoryDBContext();
                bool check = context.UpdateCategory(categ);
                if (check == true)
                {
                    TempData["UpdateMessage"] = "<script>alert('Data Has Been Updated Successfully')</script>";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            CategoryDBContext context = new CategoryDBContext();
            var row = context.GetCategories().Find(model => model.CategoryId == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(int id, Category categ)
        {
            CategoryDBContext context = new CategoryDBContext();
            bool check = context.DeleteCategory(id);
            if (check == true)
            {
                TempData["DeleteMessage"] = "<script>alert('Data Has Been Deleted Successfully')</script>";
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Index1()
        {
            ProductDBContext db = new ProductDBContext();
            List<Product> obj = db.GetProducts();
            return View(obj);
        }


        public ActionResult Create1()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create1(Product prod)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    ProductDBContext context = new ProductDBContext();
                    bool check = context.AddProduct(prod);
                    if (check == true)
                    {
                        TempData["InsertMessage"] = "<script>alert('Data Has Been Inserted Successfully')</script>";
                        ModelState.Clear();
                        return RedirectToAction("Index1");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Edit1(int id)
        {
            ProductDBContext context = new ProductDBContext();
            var row = context.GetProducts().Find(model => model.ProductId == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit1(int id, Product prod)
        {
            if (ModelState.IsValid == true)
            {
                ProductDBContext context = new ProductDBContext();
                bool check = context.UpdateProduct(prod);
                if (check == true)
                {
                    TempData["UpdateMessage"] = "<script>alert('Data Has Been Updated Successfully')</script>";
                    ModelState.Clear();
                    return RedirectToAction("Index1");
                }
            }
            return View();
        }
        public ActionResult Delete1(int id)
        {
            ProductDBContext context = new ProductDBContext();
            var row = context.GetProducts().Find(model => model.ProductId == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete1(int id, Product prod)
        {
            ProductDBContext context = new ProductDBContext();
            bool check = context.DeleteProduct(id);
            if (check == true)
            {
                TempData["DeleteMessage"] = "<script>alert('Data Has Been Deleted Successfully')</script>";
                return RedirectToAction("Index1");
            }

            return View();
        }

        public ActionResult Index2()
        {
            ProductListDBContext db = new ProductListDBContext();
            List<ProductList> obj = db.GetProductsList();
            return View(obj);
        }
    }

}