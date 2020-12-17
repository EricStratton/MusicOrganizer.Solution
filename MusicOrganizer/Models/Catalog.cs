using System.Collections.Generic;

namespace Organizer.Models
{
  public class Catalog
  {
    private static List<Catalog> _instances = new List<Catalog> {};
    public string Name { get; set; }
    public int Id { get; }
    public List<Record> Records { get; set; }
    

    public Catalog(string catalogName)
    {
      Name = catalogName;
      _instances.Add(this);
      Id = _instances.Count;
      Records = new List<Record> {};
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Catalog> GetAll()
    {
      return _instances;
    }

    public static Catalog Find(int searchId)
    {
      return _instances[searchId-1];
    }
    
    public void AddRecord(Record record)
    {
      Records.Add(record);
    }
  }
}