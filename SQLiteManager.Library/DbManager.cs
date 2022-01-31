using System.Data.SQLite;

namespace SQLiteManager.Library
  {
  public class DbManager
    {
    private static string _defaultConnectionString = "";
    public enum Status
      {
      Error = -1,
      Warning = 2,
      OK = 1
      }

    public static Status CreateDatabase(string path, bool overwrite = false)
      {

      if (!File.Exists(path) || overwrite)
        {
        var dir = Path.GetDirectoryName(path);
        if (!(string.IsNullOrWhiteSpace(dir) || Directory.Exists(dir)))
          {
          Directory.CreateDirectory(dir);
          }
        SQLiteConnection.CreateFile(path);
        _defaultConnectionString = BuildConnectionString(path);
        }
      return Status.OK;
      }

    public static Status DeleteDatabase(string path)
      {
      if (File.Exists(path))
        {
        File.Delete(path);
        return Status.OK;
        }
      return Status.Error;
      }

    public static string BuildConnectionString(string path)
      {
      return $"\"Data Source = {path}; Version = 3; \"";
      }

    public static string GetConnectionString()
      {
      if (string.IsNullOrEmpty(_defaultConnectionString))
        {
        throw new ArgumentException("Connection string not defined");
        }
      return _defaultConnectionString;
      }

    public static string GetConnectionString(string path)
      {
      if (string.IsNullOrEmpty(path))
        {
        throw new ArgumentException("Database path is invalid");
        }
      return BuildConnectionString(path);
      }
    }
  }

