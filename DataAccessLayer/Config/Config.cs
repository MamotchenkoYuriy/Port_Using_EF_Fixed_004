using System.Configuration;

namespace DataAccessLayer.Config
{
    public class Config
    {
        public static string ConnectionString(string connectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }
    }
}
