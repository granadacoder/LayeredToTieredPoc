namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Wcf.Host
{
    using System;
    using System.Configuration;
    using System.ServiceModel.Configuration;

    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Wcf.BusinessServices;

    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                UnityContainer container = new UnityContainer();
                container.LoadConfiguration();

                ServicesSection services = ConfigurationManager.GetSection("system.serviceModel/services") as ServicesSection;

                // enumerate over each <service> node
                foreach (ServiceElement currentServiceElement in services.Services)
                {
                    Console.WriteLine("Name: {0} / Behavior: {1}", currentServiceElement.Name, currentServiceElement.BehaviorConfiguration);

                    //// enumerate over all endpoints for that service
                    foreach (ServiceEndpointElement see in currentServiceElement.Endpoints)
                    {
                        Console.WriteLine("Endpoint: Address = {0} / Binding = {1} / Contract = {2}", see.Address, see.Binding, see.Contract);
                        ////host.AddServiceEndpoint(
                        Console.WriteLine();
                    }
                }

                ServiceModelEx.ServiceHost<DepartmentBusinessService> host1 = new ServiceModelEx.ServiceHost<DepartmentBusinessService>();
                host1.Open();

                foreach (var se in host1.Description.Endpoints)
                {
                    Console.WriteLine("ListenUri: " + se.ListenUri.ToString());
                    Console.WriteLine("Address: " + se.Address.Uri.ToString());
                    Console.WriteLine("Binding: " + se.Binding.Name);
                    Console.WriteLine("Contract :" + se.Contract.Name);
                    Console.WriteLine(string.Empty);
                }

                ////ServiceModelEx.ServiceHost<ZebraAsyncControllerFascade> hostAsync = new ServiceModelEx.ServiceHost<ZebraAsyncControllerFascade>();
                ////hostAsync.Open();

                Console.WriteLine("HOST is running");
                Console.ReadLine();

                host1.Close();
                ////hostAsync.Close();
            }
            catch (Exception ex)
            {
                Exception exc = ex;
                while (null != exc)
                {
                    Console.WriteLine(exc.Message);
                    exc = exc.InnerException;
                }

                Console.WriteLine("Press ENTER to Exit");
                Console.ReadLine();
            }
        }
    }
}
