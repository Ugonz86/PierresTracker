using Microsoft.AspNetCore.Mvc;
using Tracker.Models;
using System.Collections.Generic;

namespace Tracker.Controllers
{
  public class OrdersController : Controller
  {
    [HttpGet("/vendors/{vendorId}/orders/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View(model);
    }

    //This will be added later
    // [HttpGet("/vendors/{vendorId}/order/{orderId}/edit")]
    // public ActionResult Edit(int vendorId, int orderId)
    // {
    //     Vendor vendor = Vendor.Find(vendorId);
    //     Order order = Order.Find(orderId);
    //     return View(order);
    // }

    // This will be used later
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
