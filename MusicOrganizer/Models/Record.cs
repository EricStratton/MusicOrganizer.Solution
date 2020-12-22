using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Organizer.Models
{
  public class Record
  {

    public string Album { get; set; }
    // public string Artist { get; set; }
    public int Id { get; set; }

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
      cmd.CommandText = @"SELECT * FROM records;"; // records is a table within the music_organizer database
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
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM records;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Record Find(int searchId)
    {
      // Placeholder code
      Record placeholderRecord = new Record("placeholder record");
      return placeholderRecord;
    }

    public override bool Equals(System.Object otherRecord)
    {
      if(!(otherRecord is Record))
      {
        return false;
      }
      else 
      {
        Record newRecord = (Record) otherRecord;
        bool albumEquality = (this.Album == newRecord.Album);
        return albumEquality;
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO records (album) VALUES (@RecordAlbum);";
      MySqlParameter album = new MySqlParameter();
      album.ParameterName = "@RecordAlbum";
      album.Value = this.Album;
      cmd.Parameters.Add(album);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
    }
  }
}