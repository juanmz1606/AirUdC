﻿using AirUdC.Application.Contracts.Contracts.Parameters;
using AirUdC.Application.Contracts.DTO.Parameters;
using AirUdC.Application.Implementation.Mappers.Parameters;
using AirUdC.GUI.Models;
using AirUdC.GUI.Models.ReportModels;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace AirUdC.GUI.Controllers.Parameters
{
    public class CityController : Controller
    {
        private ICityApplication app;
        private ICountryApplication countryApp;

        public CityController(ICityApplication cityApplication, ICountryApplication countryApplication)
        {
            app = cityApplication;
            countryApp = countryApplication;
        }

        private CityMapperGUI mapper = new CityMapperGUI();

        // GET: City
        public ActionResult Index(string filter = "")
        {
            var list = mapper.MapperT1toT2(app.GetAllRecords(filter));
            return View(list);
        }

        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityModel cityModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (cityModel == null)
            {
                return HttpNotFound();
            }
            return View(cityModel);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            CityModel model = new CityModel();
            FillListForView(model);
            return View(model);
        }

        private void FillListForView(CityModel model)
        {
            CountryMapperGUI countryMapper = new CountryMapperGUI();
            model.CountryList = countryMapper.MapperT1toT2(countryApp.GetAllRecords(string.Empty));
        }

        // POST: City/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CityModel cityModel)
        {
            ModelState.Remove("Country.Name");
            if (ModelState.IsValid)
            {
                CityDTO cityDTO = mapper.MapperT2toT1(cityModel);
                app.CreateRecord(cityDTO);
                return RedirectToAction("Index");
            }

            return View(cityModel);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityModel cityModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (cityModel == null)
            {
                return HttpNotFound();
            }
            FillListForView(cityModel);
            return View(cityModel);
        }

        // POST: City/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CityModel cityModel)
        {
            ModelState.Remove("Country.Name");
            if (ModelState.IsValid)
            {
                CityDTO cityDTO = mapper.MapperT2toT1(cityModel);
                app.UpdateRecord(cityDTO);
                return RedirectToAction("Index");
            }
            return View(cityModel);
        }

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityModel cityModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (cityModel == null)
            {
                return HttpNotFound();
            }
            return View(cityModel);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            app.DeleteRecord(id);
            return RedirectToAction("Index");
        }

        public ActionResult GenerateReport(string format = "PDF")
        {
            var list = app.GetAllRecords(string.Empty);
            CityMapperGUI cityMapperGUI = new CityMapperGUI();
            List<CitiesByCountryReportModel> recordsList = new List<CitiesByCountryReportModel>();

            foreach (var city in list)
            {
                recordsList.Add(
                    new CitiesByCountryReportModel
                    {
                        Id = city.Id.ToString(),
                        Name = city.Name,
                        CountryId = city.Country.Id.ToString(),
                        CountryName = city.Country.Name
                    });
            }

            string reportPath = Server.MapPath("~/Reports/RdlcFiles/CitiesByCountryReport.rdlc");
            LocalReport lr = new LocalReport();

            lr.ReportPath = reportPath;
            lr.EnableHyperlinks = true;

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, fileNameExtension;

            ReportDataSource datasource = new ReportDataSource("CitiesByCountryDataSet", recordsList);
            lr.DataSources.Add(datasource);

            renderedBytes = lr.Render(
                format,
                string.Empty,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings
                );

            return File(renderedBytes, mimeType);
        }
    }
}
