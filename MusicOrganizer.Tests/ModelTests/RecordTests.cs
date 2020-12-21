using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
  
  }
}