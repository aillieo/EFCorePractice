using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace EFCorePractice.App
{
    public static class AppConfig
    {
        static AppConfig()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(ProcessDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string ProcessDirectory
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        public static IConfigurationRoot Configuration { get; }
    }
}
