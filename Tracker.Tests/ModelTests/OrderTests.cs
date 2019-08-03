using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tracker.Models;
using System;

namespace Tracker.Tests
{
  [TestClass]
  public class OrderTest : IDisposable
  {

    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("croissants", "100", "100", "08/01/2019");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {

      string description = "croissants";

      Order newOrder = new Order("croissants", "100", "100", "08/01/2019");
      string result = newOrder.Description;


      Assert.AreEqual(description, result);
    }

    // [TestMethod]
    // public void SetDescription_SetDescription_String()
    // {
    //
    //   string description = "croissants";
    //   string quantity = "100";
    //   string price = "100";
    //   string date = "08/01/2019";
    //
    //   Order newOrder = new Order(description, quantity, price, date);
    //
    //   string updatedDescription = ("french bread");
    //   newOrder.Description = updatedDescription;
    //   string result = newOrder.Description;
    //
    //   string updatedQuantity = ("200");
    //   newOrder.Quantity = updatedQuantity;
    //   string result2 = newOrder.Quantity;
    //
    //   string updatedPrice = ("200");
    //   newOrder.Price = updatedPrice;
    //   string result3 = newOrder.Price;
    //
    //   string updatedDate = ("08/02/2019");
    //   newOrder.Date = updatedDate;
    //   string result4 = newOrder.Date;
    //
    //   Assert.AreEqual(updatedDescription, updatedQuantity, updatedPrice, updatedDate);
    // }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {

      List<Order> newList = new List<Order> { };

      List<Order> result = Order.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    // [TestMethod]
    // public void GetAll_ReturnsOrders_OrderList()
    // {
    //
    //   string description01 = ("croissants", "100", "100", "08/01/2019");
    //   string description02 = ("bread", "100", "100", "08/01/2019");
    //   Order newOrder1 = new Order(description01, quantity01, price01, date01);
    //   Order newOrder2 = new Order(description02, quantity02, price02, date02);
    //   List<Order> newList = new List<Order> { newOrder1, newOrder2 };
    //
    //
    //   List<Order> result = Order.GetAll();
    //
    //
    //   CollectionAssert.AreEqual(newList, result);
    // }

    [TestMethod]
    public void GetId_OrdersInstantiateWithAnIdAndGetterReturns_Int()
    {
      string description = ("croissants");
      string quantity = ("100");
      string price = ("100");
      string date = ("08/01/2019");
      Order newOrder = new Order(description, quantity, price, date);

      int result = newOrder.Id;

      Assert.AreEqual(1, result);
    }

    // [TestMethod]
    // public void Find_ReturnsCorrectOrder_Order()
    // {
    //   string description01 = ("croissants");
    //   string description02 = ("bread");
    //   Order newOrder1 = new Order(description01);
    //   Order newOrder2 = new Order(description02);
    //
    //   Order result = Order.Find(2);
    //
    //   Assert.AreEqual(newOrder2, result);
    // }
  }
}
