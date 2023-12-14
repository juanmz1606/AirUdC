using AirUdC.Application.Contracts.Contracts.Parameters;
using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.Application.Implementation.Mappers.Parameters;
using AirUdC.GUI.Mappers.Parameters;
using AirUdC.GUI.Models.Parameters;
using AirUdC.Infastructure.Contracts.DbModel.Parameters;
using System.Data.Entity.Migrations.Model;
using System.EnterpriseServices;
using System.Net;
using System.Web.Mvc;

namespace AirUdC.GUI.Controllers.Parameters
{
    public class PropertyController : Controller
    {
        private IPropertyApplication app;
        private ICityApplication cityApp;
        private IPropertyOwnerApplication propertyOwnerApp;

        public PropertyController(IPropertyApplication propertyApplication,
            ICityApplication cityApplication, IPropertyOwnerApplication propertyOwnerApplication)
        {
            app = propertyApplication;
            cityApp = cityApplication;
            propertyOwnerApp = propertyOwnerApplication;
        }

        private PropertyMapperGUI mapper = new PropertyMapperGUI();

        // GET: Property
        public ActionResult Index(string filter ="")
        {
            var list = mapper.MapperT1toT2(app.GetAllRecords(filter));
            return View(list);
        }

        // GET: Property/Details/5
        public ActionResult Details(long id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property_Model propertyModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (propertyModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyModel);
        }

        // GET: Property/Create
        public ActionResult Create()
        {
            Property_Model model = new Property_Model();
            FillListForView(model);
            return View(model);
        }

        private void FillListForView(Property_Model model)
        {
            CityMapperGUI cityMapper = new CityMapperGUI();
            PropertyOwnerMapperGUI propertyOwnerMapper = new PropertyOwnerMapperGUI();
            model.CityList = cityMapper.MapperT1toT2(cityApp.GetAllRecords(string.Empty));
            model.PropertyOwnerList = propertyOwnerMapper.MapperT1toT2(propertyOwnerApp.GetAllRecords(string.Empty));
        }

        // POST: Property/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Property_Model propertyModel)
        {
            ModelState.Remove("City.Name");
            ModelState.Remove("PropertyOwner.FirstName");
            ModelState.Remove("PropertyOwner.FamilyName");
            ModelState.Remove("PropertyOwner.Email");
            ModelState.Remove("PropertyOwner.Cellphone");
            if (ModelState.IsValid)
            {
                PropertyDTO propertyDTO = mapper.MapperT2toT1(propertyModel);
                app.CreateRecord(propertyDTO);
                return RedirectToAction("Index");
            }
            return View(propertyModel);
        }

        // GET: Property/Edit/5
        public ActionResult Edit(long id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property_Model propertyModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (propertyModel == null)
            {
                return HttpNotFound();
            }
            FillListForView(propertyModel);
            return View(propertyModel);
        }

        // POST: Property/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Property_Model property_Model)
        {
            ModelState.Remove("City.Name");
            ModelState.Remove("PropertyOwner.FirstName");
            ModelState.Remove("PropertyOwner.FamilyName");
            ModelState.Remove("PropertyOwner.Email");
            ModelState.Remove("PropertyOwner.Cellphone");
            if (ModelState.IsValid)
            {
                PropertyDTO propertyDTO = mapper.MapperT2toT1(property_Model);
                app.UpdateRecord(propertyDTO);
                return RedirectToAction("Index");
            }
            return View(property_Model);
        }

        // GET: Property/Delete/5
        public ActionResult Delete(long id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property_Model property_Model = mapper.MapperT1toT2(app.GetRecord(id));
            if (property_Model == null)
            {
                return HttpNotFound();
            }
            return View(property_Model);
        }

        // POST: Property/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            app.DeleteRecord(id);
            return RedirectToAction("Index");
        }
    }
}
