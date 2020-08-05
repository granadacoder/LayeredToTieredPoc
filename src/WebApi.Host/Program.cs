namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.Host
{
    using System;

    using Microsoft.Owin.Hosting;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.Host.Keys;

    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string baseAddress = System.Configuration.ConfigurationManager.AppSettings[AppSettingKeys.WebApiBaseAddress];

                if (string.IsNullOrEmpty(baseAddress))
                {
                    throw new ArgumentNullException(string.Format("AppSetting '{0}' was not defined.", AppSettingKeys.WebApiBaseAddress));
                }

                // Start OWIN host 
                using (IDisposable st = WebApp.Start<Startup>(url: baseAddress))
                {
                    Console.WriteLine("WebApp.Start Running");
                    Console.WriteLine("Press ENTER to Exit WebApp");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Exception exc = ex;
                while (null != exc)
                {
                    Console.WriteLine(exc.Message);
                    exc = exc.InnerException;
                }
            }
        }
    }
}
