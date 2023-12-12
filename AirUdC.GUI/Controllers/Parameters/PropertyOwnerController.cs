using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirUdC.Application.Contracts.Contracts.Parameters;
using AirUdC.Application.Implementation.Mappers.Parameters;
using AirUdC.GUI.Mappers.Parameters;
using AirUdC.GUI.Models.Parameters;
using AirUdC.Infrastructure.Implementation.DataModel;

namespace AirUdC.GUI.Controllers.Parameters
{
    public class PropertyOwnerController : Controller
    {
        private IPropertyOwnerApplication app;

        private PropertyOwnerMapperGUI mapper = new PropertyOwnerMapperGUI();

        public PropertyOwnerController(IPropertyOwnerApplication propertyOwnerApplication)
        {
            app = propertyOwnerApplication;
        }

        // GET: PropertyOwner
        public ActionResult Index()
        {
            return View(db.PropertyOwnerModels.ToList());
        }

        // GET: PropertyOwner/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel propertyOwnerModel = db.PropertyOwnerModels.Find(id);
            if (propertyOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyOwnerModel);
        }

        // GET: PropertyOwner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyOwner/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,FamilyName,Email,Cellphone,Photo")] PropertyOwnerModel propertyOwnerModel)
        {
            if (ModelState.IsValid)
            {
                db.PropertyOwnerModels.Add(propertyOwnerModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propertyOwnerModel);
        }

        // GET: PropertyOwner/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel propertyOwnerModel = db.PropertyOwnerModels.Find(id);
            if (propertyOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyOwnerModel);
        }

        // POST: PropertyOwner/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,FamilyName,Email,Cellphone,Photo")] PropertyOwnerModel propertyOwnerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyOwnerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propertyOwnerModel);
        }

        // GET: PropertyOwner/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel propertyOwnerModel = db.PropertyOwnerModels.Find(id);
            if (propertyOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyOwnerModel);
        }

        // POST: PropertyOwner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PropertyOwnerModel propertyOwnerModel = db.PropertyOwnerModels.Find(id);
            db.PropertyOwnerModels.Remove(propertyOwnerModel);
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
