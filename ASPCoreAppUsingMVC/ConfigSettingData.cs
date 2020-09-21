using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreAppUsingMVC
{
    public class ConfigSettingData
    {
        public string ConnectionString { get; set; }
        public ConfigSection ConfigSection { get; set; }
        public SecurityConfig SecurityConfig { get; set; }
    }

    public class ConfigSection
    {
        public string ConnectionString { get; set; }
    }

    public class SecurityConfig
    {
        public List<String> JwTDomains { get; set; }
    }
}
