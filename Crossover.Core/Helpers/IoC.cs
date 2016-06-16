using System;
using System.Configuration;
using System.IO;
using Spring.Context;
using Spring.Context.Support;

namespace Crossover.Core.Helpers
{
    public static class IoC
    {
        private static readonly IApplicationContext AppContext = new XmlApplicationContext(false, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.IsNullOrEmpty(ConfigurationManager.AppSettings["SpringFilePath"]) ? "spring.cfg.xml" : ConfigurationManager.AppSettings["SpringFilePath"]));

        public static T Resolve<T>(string name)
        {
            return (T)AppContext.GetObject(name);
        }

        public static bool Exists(string name)
        {
            return AppContext.ContainsObjectDefinition(name);
        }
    }
}