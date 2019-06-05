using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlShop
{
    public class AppSetting
    {
        Configuration config;

        public AppSetting()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        //Get connection string from App.Config file
        public string GetConnectionString(string key)
        {
            if (config.ConnectionStrings.ConnectionStrings[key] !=null)
                return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
            return null;
        }
        //Save connection string to App.config file
        public void SaveConnectionString(string key, string value)
        {
            //chua có key name connect string thì tạo mới
            if (config.ConnectionStrings.ConnectionStrings[key]==null) 
            {
                config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(key, string.Empty));
            }
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
            config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
            //config.ConnectionStrings.ConnectionStrings[key].
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}