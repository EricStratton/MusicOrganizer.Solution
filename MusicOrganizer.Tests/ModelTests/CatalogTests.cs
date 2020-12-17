using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Organizer.Models;

namespace Organizer.Tests
{
  [TestClass]
  public class CatalogTests
  {
    [TestClass]
    public class RecordTest 
    {
      [TestMethod]
      public void RecordConstructor_CreatesInstanceOfRecord_Record()
      {
        Catalog newCatalog = new Catalog();
        Assert.AreEqual(typeof(Catalog), newCatalog.GetType());
      }
    }
  }
}