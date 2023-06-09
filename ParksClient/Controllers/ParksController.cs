using Microsoft.AspNetCore.Mvc;
using ParksClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using System.Diagnostics;

namespace CretaceousClient.Controllers;

public class ParksController : Controller
{
  public class AnimalsController : Controller
  {
    public IActionResult Index()
    {
      List<Park> parks = Park.GetParks();
      return View(parks);
    }

    public IActionResult Details(int id)
    {
      Park park = Park.GetDetails(id);
      return View(park);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Park park)
    {
      Park.Post(park);
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Park park = Park.GetDetails(id);
      return View(park);
    }

    [HttpPost]
    public ActionResult Edit(Park park)
    {
      Park.Put(park);
      return RedirectToAction("Details", new { id = park.ParkId});
    }

    public ActionResult Delete(int id)
    {
      Park park = Park.GetDetails(id);
      return View(park);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Park.Delete(id);
      return RedirectToAction("Index");
    }
  }  
}  