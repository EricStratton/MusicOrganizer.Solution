using System.Collections.Generic;
using Mysql.Data.MySqlClient;

namespace Organizer.Models
{
  public class Record
  {

    public string Album { get; set; }
    // public string Artist { get; set; }
    public int Id { get; }

    public Record(string albumName)
    {
      Album = albumName;
      // Artist = artistName;
    }

    public Record(string albumName, int albumId)
      : this(albumName)
    {
      Id = albumId;
    }
    
    public static List<Record> GetAll()
    {
      List<Record> allRecords = new List<Record> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int recordId = rdr.GetInt32(0);
        string albumName = rdr.GetString(1);
        Record newRecord = new Record(albumName, recordId);
        allRecords.Add(newRecord);
      }
      conn.Close();
      if (conn != null) // Am i still recieving data from the server? if yes, dispose connection.
      {
        conn.Dispose();
      }
      return allRecords;
    }

    public static void ClearAll()
    {
    }

    public static Record Find(int searchId)
    {
      // Placeholder code
      Record placeholderRecord = new Record("placeholder record");
      return placeholderRecord;
    }
  }
}