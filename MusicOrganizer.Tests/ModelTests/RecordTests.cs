using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Organizer.Models;
using MySql.Data.MySqlClient;

namespace Organizer.Tests
{
  [TestClass]
  public class RecordTest : IDisposable
  {

    public void Dispose()
    {
      Record.ClearAll();
    }

    public RecordTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=music_organizer_test;";
    }

    [TestMethod]
    public void RecordConstructor_CreatesInstanceOfRecord_Record()
    {
      Record newRecord = new Record("Test", 0);
      Assert.AreEqual(typeof(Record), newRecord.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_RecordList()
    {
      List<Record> newList = new List<Record> {  };
      List<Record> result = Record.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfAlbumsAreTheSame_Record()
    {
      Record firstRecord = new Record("Big Dumps");
      Record secondRecord = new Record("Big Dumps");
      Assert.AreEqual(firstRecord, secondRecord);
    }
  }
}