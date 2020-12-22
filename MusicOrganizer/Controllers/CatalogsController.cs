using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Organizer.Models;

namespace Organizer.Controllers
{
  public class CatalogsController : Controller
  {
    [HttpGet("/catalogs")]
    public ActionResult Index()
    {
      List<Catalog> allCatalogs = Catalog.GetAll();
      return View(allCatalogs);
    }

    [HttpGet("/catalogs/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/catalogs")] // Create a new catalog
    public ActionResult Create(string catalogName)
    {
      Catalog newCatalog = new Catalog(catalogName);
      return RedirectToAction("Index");
    }

    [HttpGet("/catalogs/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Catalog selectedCatalog = Catalog.Find(id);
      List<Record> catalogRecords = selectedCatalog.Records;
      model.Add("catalog", selectedCatalog);
      model.Add("records", catalogRecords);
      return View(model);
    }

    [HttpPost("/catalogs/{catalogId}/records")] // 'Create' a new record
    public ActionResult Create(int catalogId, string albumName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Catalog foundCatalog = Catalog.Find(catalogId);
      Record newRecord = new Record(albumName);
      newRecord.Save();
      foundCatalog.AddRecord(newRecord);
      List<Record> catalogRecords = foundCatalog.Records;
      model.Add("records", catalogRecords);
      model.Add("catalog", foundCatalog);
      return View("Show", model);
    }
  }
}