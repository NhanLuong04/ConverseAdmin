using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Converse.Models;

namespace Converse.Areas.Admin.Controllers
{
    public class ProDetailsController : Controller
    {
        private ConverseStoreEntities db = new ConverseStoreEntities();

        // GET: Admin/ProDetails
        public ActionResult Index()
        {
            var proDetails = db.ProDetails.Include(p => p.Color).Include(p => p.Product).Include(p => p.Size1).Include(p => p.Supplier);
            return View(proDetails.ToList());
        }
        public ActionResult DSKhoHang()
        {
            return View(db.ProDetails.ToList());
        }
        // GET: Admin/ProDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProDetail proDetail = db.ProDetails.Find(id);
            if (proDetail == null)
            {
                return HttpNotFound();
            }
            return View(proDetail);
        }

        // GET: Admin/ProDetails/Create
        public ActionResult Create()
        {
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName");
            ViewBag.ProID = new SelectList(db.Products, "ProID", "ProName");
            ViewBag.SIZE = new SelectList(db.Sizes, "SizeID", "SizeNum");
            ViewBag.SupID = new SelectList(db.Suppliers, "SupID", "SupName");
            return View();
        }

        // POST: Admin/ProDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProDeID,ProID,SupID,ColorID,Quantity,SIZE,SHAPE,KEYWORD,Price,Image1,Image2,Image3,Image4,Image5," + "UploadImg1,UploadImg2,UploadImg3,UploadImg4,UploadImg5")] ProDetail proDetail)
        {
            if (ModelState.IsValid)
            {
                var product = db.Products.Find(proDetail.ProID);
                if (proDetail.UploadImg1 != null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(proDetail.UploadImg1.FileName);
                    proDetail.Image1 = path + filename;
                    proDetail.UploadImg1.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                if (proDetail.UploadImg2 != null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(proDetail.UploadImg2.FileName);
                    proDetail.Image2 = path + filename;
                    proDetail.UploadImg2.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                if (proDetail.UploadImg3 != null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(proDetail.UploadImg3.FileName);
                    proDetail.Image3 = path + filename;
                    proDetail.UploadImg3.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                if (proDetail.UploadImg4 != null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(proDetail.UploadImg4.FileName);
                    proDetail.Image4 = path + filename;
                    proDetail.UploadImg4.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                if (proDetail.UploadImg5 != null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(proDetail.UploadImg5.FileName);
                    proDetail.Image5 = path + filename;
                    proDetail.UploadImg5.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                proDetail.Quantity = product.RemainQuantity;
                db.ProDetails.Add(proDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", proDetail.ColorID);
            ViewBag.ProID = new SelectList(db.Products, "ProID", "ProName", proDetail.ProID);
            ViewBag.SIZE = new SelectList(db.Sizes, "SizeID", "SizeNum", proDetail.SIZE);
            ViewBag.SupID = new SelectList(db.Suppliers, "SupID", "SupName", proDetail.SupID);
            return View(proDetail);
        }

        // GET: Admin/ProDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProDetail proDetail = db.ProDetails.Find(id);
            if (proDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", proDetail.ColorID);
            ViewBag.ProID = new SelectList(db.Products, "ProID", "ProName", proDetail.ProID);
            ViewBag.SIZE = new SelectList(db.Sizes, "SizeID", "SizeNum", proDetail.SIZE);
            ViewBag.SupID = new SelectList(db.Suppliers, "SupID", "SupName", proDetail.SupID);
            return View(proDetail);
        }

        // POST: Admin/ProDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProDeID,ProID,SupID,ColorID,Quantity,SIZE,SHAPE,KEYWORD,Price,Image1,Image2,Image3,Image4,Image5," + "UploadImg1,UploadImg2,UploadImg3,UploadImg4,UploadImg5")] ProDetail proDetail)
        {
            if (ModelState.IsValid)
            {
                if (proDetail.UploadImg1 != null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(proDetail.UploadImg1.FileName);
                    proDetail.Image1 = path + filename;
                    proDetail.UploadImg1.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                if (proDetail.UploadImg2 != null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(proDetail.UploadImg2.FileName);
                    proDetail.Image2 = path + filename;
                    proDetail.UploadImg2.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                if (proDetail.UploadImg3 != null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(proDetail.UploadImg3.FileName);
                    proDetail.Image3 = path + filename;
                    proDetail.UploadImg3.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                if (proDetail.UploadImg4 != null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(proDetail.UploadImg4.FileName);
                    proDetail.Image4 = path + filename;
                    proDetail.UploadImg4.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                if (proDetail.UploadImg5 != null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(proDetail.UploadImg5.FileName);
                    proDetail.Image5 = path + filename;
                    proDetail.UploadImg5.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                db.Entry(proDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", proDetail.ColorID);
            ViewBag.ProID = new SelectList(db.Products, "ProID", "ProName", proDetail.ProID);
            ViewBag.SIZE = new SelectList(db.Sizes, "SizeID", "SizeNum", proDetail.SIZE);
            ViewBag.SupID = new SelectList(db.Suppliers, "SupID", "SupName", proDetail.SupID);
            return View(proDetail);
        }

        // GET: Admin/ProDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProDetail proDetail = db.ProDetails.Find(id);
            if (proDetail == null)
            {
                return HttpNotFound();
            }
            return View(proDetail);
        }

        // POST: Admin/ProDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProDetail proDetail = db.ProDetails.Find(id);
            db.ProDetails.Remove(proDetail);
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
