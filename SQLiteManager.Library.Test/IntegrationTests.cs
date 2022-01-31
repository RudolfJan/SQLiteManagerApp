using System.IO;
using Xunit;

namespace SQLiteManager.Library.Test
  {
  public class IntegrationTests
    {
    public static string ArrangeStartCondition()
      {
      // Arrange
      var dir = "C:\\Temp";
      var dbPath = $"{ dir}\\testDatabase.db";

      if (!Directory.Exists(dir))
        {
        Directory.CreateDirectory(dir);
        }

      if (File.Exists(dbPath))
        {
        File.Delete(dbPath);
        }
      return dbPath;
      }

    [Fact]
    public void DatabaseShouldBeCreated()
      {
      var path = ArrangeStartCondition();
      DbManager.CreateDatabase(path);
      Assert.True(File.Exists(path));
      }

    [Fact]
    public void DatabaseShouldBeDeleted()
      {
      var path = ArrangeStartCondition();
      DbManager.CreateDatabase(path);
      DbManager.DeleteDatabase(path);
      Assert.False(File.Exists(path));
      }
    }
  }
