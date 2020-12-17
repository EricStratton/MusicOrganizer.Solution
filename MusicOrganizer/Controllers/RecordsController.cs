using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Organizer.Models;

namespace Organizer.Controllers
{
  public class RecordsController : Controller
  {
    [HttpGet("/catalogs/{catalogId}/records/new")]
    public ActionResult New(int catalogId)
    {
      Catalog catalog = Catalog.Find(catalogId);
      return View(catalog);
    }

    [HttpGet("/catalogs/{catalogId}/records/{recordId}")]
    public ActionResult Show(int catalogId, int recordId)
    {
      Record record = Record.Find(recordId);
      Catalog catalog = Catalog.Find(catalogId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("record", record);
      model.Add("catalog", catalog);
      return View(model);
    }

    // [HttpPost("/records/delete")]
    // public ActionResult DeleteAll()
    // {
    //   Record.ClearAll();
    //   return View();
    // }
  }
}