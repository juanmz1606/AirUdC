using AirUdC.Application.Contracts.Contracts.Parameters;
using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.Application.Implementation.Mappers.Parameters;
using AirUdC.GUI.Models;
using System.Net;
using System.Web.Mvc;

namespace AirUdC.GUI.Controllers.Parameters
{
    public class CountryController : Controller
    {
        private ICountryApplication app;

        private CountryMapperGUI mapper = new CountryMapperGUI();

        public CountryController(ICountryApplication countryApplication)
        {
            app = countryApplication;
        }

        // GET: Country
        public ActionResult Index(string filter = "")
        {
            var list = mapper.MapperT1toT2(app.GetAllRecords(filter));
            return View(list);
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModel countryModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (countryModel == null)
            {
                return HttpNotFound();
            }
            return View(countryModel);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                CountryDTO countryDTO = mapper.MapperT2toT1(countryModel);
                app.CreateRecord(countryDTO);
                return RedirectToAction("Index");
            }

            return View(countryModel);
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModel countryModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (countryModel == null)
            {
                return HttpNotFound();
            }
            return View(countryModel);
        }

        // POST: Country/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                CountryDTO countryDTO = mapper.MapperT2toT1(countryModel);
                app.UpdateRecord(countryDTO);
                return RedirectToAction("Index");
            }
            return View(countryModel);
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModel countryModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (countryModel == null)
            {
                return HttpNotFound();
            }
            return View(countryModel);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            app.DeleteRecord(id);
            return RedirectToAction("Index");
        }
    }
}
