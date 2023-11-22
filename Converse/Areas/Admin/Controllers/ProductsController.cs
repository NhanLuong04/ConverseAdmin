using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Converse.Models;
using System.IO;
using PagedList;

namespace Converse.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();

        // GET: Admin/Products
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            //var products = db.Products.Include(p => p.Category);
            var lstProduct = new List<Product>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstProduct = db.Products.Where(p => p.ProName.Contains(SearchString)).ToList();
            }
            else
            {
                lstProduct = db.Products.Include(p => p.Category).ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstProduct = lstProduct.OrderByDescending(n => n.CatID).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }


        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var proDetail = db.ProDetails.Where(p => p.ProID == id).ToList();
            if (proDetail == null || proDetail.Count == 0)
            {
                return RedirectToAction("Create", "ProDetails");
            }
            return View(proDetail);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProID,CatID,ProName,NameDecription,ProImage,ProImageHover,SoldQuantity,RemainQuantity,DISCOUNT,CreatedDate," + "UploadImage, UploadImageHover")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.UploadImage != null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(product.UploadImage.FileName);
                    product.ProImage = path + filename;
                    product.UploadImage.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                if (product.UploadImageHover != null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(product.UploadImageHover.FileName);
                    product.ProImageHover = path + filename;
                    product.UploadImageHover.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                product.CreatedDate = DateTime.Today;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProID,CatID,ProName,NameDecription,ProImage,ProImageHover,SoldQuantity,RemainQuantity,DISCOUNT,CreatedDate," + "UploadImage, UploadImageHover")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.UploadImage != null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(product.UploadImage.FileName);
                    product.ProImage = path + filename;
                    product.UploadImage.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                if (product.UploadImageHover != null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(product.UploadImageHover.FileName);
                    product.ProImageHover = path + filename;
                    product.UploadImageHover.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
