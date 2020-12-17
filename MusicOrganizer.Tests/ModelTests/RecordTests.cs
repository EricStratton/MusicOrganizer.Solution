using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Organizer.Models;

namespace Organizer.Tests
{
  [TestClass]
  public class RecordTest 
  {

    [TestMethod]
    public void RecordConstructor_CreatesInstanceOfRecord_Record()
    {
      Record newRecord = new Record("Test", "Test");
      Assert.AreEqual(typeof(Record), newRecord.GetType());
    }
  
  }
}