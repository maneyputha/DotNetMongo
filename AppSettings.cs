using Microsoft.Extensions.Configuration;
using System.IO;

namespace Entitities
{
    /// <summary>
    ///    AppSettings class is a helper class.
    ///    Helps to load data from the appsetting.json.
    ///    Created By - Manendra Ranathunga
    ///    Created Date - 18.06.2021
    /// </summary>
    public class AppSettings
    {

        /// <summary>
        ///    Retrieves a section from the appsetting.json.
        ///    <param>
        ///    mainKey (string) - the Main key of the section to be retrieved. 
        ///    subKey (string) - the Sub key of the item to be retrieved.
        ///    </param>
        ///    <returns>
        ///    Returns a string containing the relevant settings.
        ///    </returns>
        ///    Created By - Manendra Ranathunga
        ///    Created Date - 18.06.2021
        /// </summary>
        public static string GetSettingValue(string mainKey, string subKey)
        {
            return Configuration.GetSection(mainKey).GetValue<string>(subKey);
        }


        private static IConfigurationRoot _configuration;
        private static IConfigurationRoot Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    IConfigurationBuilder builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();
                    _configuration = builder.Build();
                }
                return _configuration;
            }
        }

    }
}
