using AirUdC.Application.Contracts.Contracts.Parameters;
using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.GUI.Mappers.Parameters;
using AirUdC.GUI.Models.Parameters;
using System.Net;
using System.Web.Mvc;

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
        public ActionResult Index(string filter = "")
        {
            var list = mapper.MapperT1toT2(app.GetAllRecords(filter));
            return View(list);
        }

        // GET: PropertyOwner/Details/5
        public ActionResult Details(long id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel propertyOwnerModel = mapper.MapperT1toT2(app.GetRecord(id));
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
                PropertyOwnerDTO propertyOwnerDTO = mapper.MapperT2toT1(propertyOwnerModel);
                app.CreateRecord(propertyOwnerDTO);
                return RedirectToAction("Index");
            }

            return View(propertyOwnerModel);
        }

        // GET: PropertyOwner/Edit/5
        public ActionResult Edit(long id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel propertyOwnerModel = mapper.MapperT1toT2(app.GetRecord(id));
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
                PropertyOwnerDTO propertyOwnerDTO = mapper.MapperT2toT1(propertyOwnerModel);
                app.UpdateRecord(propertyOwnerDTO);
                return RedirectToAction("Index");
            }
            return View(propertyOwnerModel);
        }

        // GET: PropertyOwner/Delete/5
        public ActionResult Delete(long id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel propertyOwnerModel = mapper.MapperT1toT2(app.GetRecord(id));
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
            app.DeleteRecord(id);
            return RedirectToAction("Index");
        }
    }
}
