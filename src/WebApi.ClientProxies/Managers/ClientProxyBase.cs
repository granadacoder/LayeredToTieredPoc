namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.ClientProxies.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.ClientProxies.Keys;
    
    public abstract class ClientProxyBase
    {
        public static readonly string JsonApplication = "application/json";

        public ClientProxyBase()
        {
            string baseAddress = System.Configuration.ConfigurationManager.AppSettings[AppSettingKeys.WebApiBaseAddress];

            if (string.IsNullOrEmpty(baseAddress))
            {
                throw new ArgumentNullException(string.Format("AppSetting '{0}' was not defined.", AppSettingKeys.WebApiBaseAddress));
            }

            this.BaseAddress = baseAddress;
        }

        public string BaseAddress { get; private set; }

        internal void DebugWriteLine(string msg)
        {
            Console.WriteLine(msg);
        }

        protected string GenerateFullAddress(string suffix)
        {
            string returnValue = this.BaseAddress + suffix;
            Console.WriteLine("About use URI : '{0}'", returnValue);
            return returnValue;
        }
    }
}
