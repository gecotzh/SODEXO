using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodexo.EPedidos.Utilidades
{
    public class Configuacion
    {
        public static string GetKeyValue(string KeyName)
        {
            return ConfigurationManager.AppSettings[KeyName].ToString();
        }

        public static string GetConnectionValue(string ConnectionName)
        {
            return ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString;
        }
    }
}
