using AirUdC.Application.Contracts.Contracts.Parameters;
using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.GUI.Mappers.Parameters;
using AirUdC.GUI.Models.Parameters;
using System.Net;
using System.Web.Mvc;

namespace AirUdC.GUI.Controllers.Parameters
{
    public class CustomerController : Controller
    {


        private ICustomerApplication app;

        private CustomerMapperGUI mapper = new CustomerMapperGUI();

        public CustomerController(ICustomerApplication customerApplication)
        {
            app = customerApplication;
        }

        // GET: Customer
        public ActionResult Index(string filter = "")
        {
            var list = mapper.MapperT1toT2(app.GetAllRecords(filter));
            return View(list);
        }

        // GET: Customer/Details/5
        public ActionResult Details(long id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel customerModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (customerModel == null)
            {
                return HttpNotFound();
            }
            return View(customerModel);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,FamilyName,Email,Cellphone,Photo")] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                CustomerDTO customerDTO = mapper.MapperT2toT1(customerModel);
                app.CreateRecord(customerDTO);
                return RedirectToAction("Index");
            }

            return View(customerModel);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(long id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel customerModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (customerModel == null)
            {
                return HttpNotFound();
            }
            return View(customerModel);
        }

        // POST: Customer/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,FamilyName,Email,Cellphone,Photo")] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                CustomerDTO customerDTO = mapper.MapperT2toT1(customerModel);
                app.UpdateRecord(customerDTO);
                return RedirectToAction("Index");
            }
            return View(customerModel);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(long id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel customerModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (customerModel == null)
            {
                return HttpNotFound();
            }
            return View(customerModel);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            app.DeleteRecord(id);
            return RedirectToAction("Index");
        }


    }
}
