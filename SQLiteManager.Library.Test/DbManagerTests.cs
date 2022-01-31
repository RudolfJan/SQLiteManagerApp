using System.IO;
using Xunit;

namespace SQLiteManager.Library.Test
  {
  public class DbManagerTests
    {
    [Theory]
    [InlineData(null, DbManager.Status.Error)]
    [InlineData("", DbManager.Status.Error)]
    public void CreateDatabase_ShouldFail(string path, DbManager.Status expected)
      {
      var actual = DbManager.CreateDatabase(path);
      Assert.Equal(expected, actual);
      }

    [Fact]
    public void CreateDataBase_ShouldThrowIOException()
      {
      var path = "invalid\\\\path\\\\";
      Assert.Throws<IOException>(() => DbManager.CreateDatabase(path, true));
      }

    [Theory]
    [InlineData(null, DbManager.Status.Error)]
    [InlineData("", DbManager.Status.Error)]
    [InlineData("this path probably does not exist", DbManager.Status.Error)]
    public void DeleteDatabaseShouldFail(string path, DbManager.Status expected)
      {
      var actual = DbManager.DeleteDatabase(path);
      Assert.Equal(expected, actual);
      }

    [Theory]
    [InlineData("valid\\path", "\"Data Source = valid\\path; Version = 3; \"")]
    public void BuildConnectionString_ShouldReturnValidString(string path, string expected)
      {
      var actual = DbManager.BuildConnectionString(path);
      Assert.Equal(expected, actual);
      }


    }
  }
