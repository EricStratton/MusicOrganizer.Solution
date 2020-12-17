using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Organizer.Models;

namespace Organizer.Tests
{
  [TestClass]
  public class CatalogTests
  {
    
    [TestMethod]
    public void RecordConstructor_CreatesInstanceOfRecord_Record()
    {
      Catalog newCatalog = new Catalog("Test");
      Assert.AreEqual(typeof(Catalog), newCatalog.GetType());
    }
    
  }
}