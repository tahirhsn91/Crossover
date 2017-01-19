using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossover.Core.Helpers
{
    public static class ConfigurationHelper
    {
        private static int requestExpiry = string.IsNullOrEmpty(ConfigurationManager.AppSettings["RequestExpiry"]) ? 1 : Convert.ToInt32(ConfigurationManager.AppSettings["RequestExpiry"].ToString());

        private static int rateLimit = string.IsNullOrEmpty(ConfigurationManager.AppSettings["RateLimit"]) ? 60 : Convert.ToInt32(ConfigurationManager.AppSettings["RateLimit"].ToString());

        private static int specialWaiting = string.IsNullOrEmpty(ConfigurationManager.AppSettings["SpecialWaiting"]) ? 5 : Convert.ToInt32(ConfigurationManager.AppSettings["SpecialWaiting"].ToString());

        public static int RequestExpiry
        {
            get
            {
                return requestExpiry;
            }
        }

        public static int RateLimit
        {
            get
            {
                return rateLimit;
            }
        }

        public static int SpecialWaiting
        {
            get
            {
                return specialWaiting;
            }
        }
    }
}
