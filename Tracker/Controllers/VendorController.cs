using System.Collections.Generic;
// using System.Windows.Controls;
using System;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models;

namespace Tracker.Controllers
{
  public class VendorsController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string vendorName)
    {
      Vendor newVendor = new Vendor(vendorName);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> vendorOrders = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("orders", vendorOrders);
      return View(model);
    }

    // This one creates new Orders within a given Vendor, not new Vendors:
    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string orderDescription, string quantityDescription, string priceDescription, string dateDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(vendorId);
      // DatePicker datePicker = new DatePicker();
      Order newOrder = new Order(orderDescription, quantityDescription, priceDescription, dateDescription);
      foundVendor.AddOrder(newOrder);
      List<Order> vendorOrders = foundVendor.Orders;
      model.Add("orders", vendorOrders);
      model.Add("vendor", foundVendor);
      return View("Show", model);
    }

    // [HttpPost("/vendors/{vendorId}/orders/delete")]
    // public ActionResult Delete(int vendorId)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Vendor selectedVendor = Vendor.Find(vendorId);
    //   selectedVendor.ClearAllVendorOrders();
    //   return View("Show", model);
    // }

  }
}
