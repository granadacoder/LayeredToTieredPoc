namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.ClientProxies.Managers
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Args.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Compositions.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.ServiceInterfaces.Managers;

    public class DepartmentManagerClientProxy : ClientProxyBase, IDepartmentManager
    {
        public static readonly string UrlSuffixGetDepartmentAllWrapper = @"api/DepartmentBusinessService/GetDepartmentAllWrapper";
        public static readonly string UrlSuffixGetDepartmentAddEditSingleWrapper = @"api/DepartmentBusinessService/GetDepartmentAddEditSingleWrapper";
        public static readonly string UrlSuffixAddDepartment = @"api/DepartmentBusinessService/AddDepartment";
        public static readonly string UrlSuffixUpdateDepartment = @"api/DepartmentBusinessService/UpdateDepartment";

        public DepartmentAllWrapper GetDepartmentAllWrapper()
        {
            DepartmentAllWrapper returnItem = null;

            // Create HttpCient and make a request to api/values 
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this.BaseAddress);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonApplication));

            HttpResponseMessage response = client.GetAsync(this.GenerateFullAddress(UrlSuffixGetDepartmentAllWrapper)).Result;

            this.DebugWriteLine(string.Empty);
            this.DebugWriteLine(response.ToString());
            this.DebugWriteLine(response.Content.ReadAsStringAsync().Result);
            this.DebugWriteLine(string.Empty);

            if (response.IsSuccessStatusCode)
            {
                returnItem = response.Content.ReadAsAsync<DepartmentAllWrapper>().Result;
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase + " " + response.RequestMessage);
            }

            return returnItem;
        }

        public DepartmentAddEditSingleWrapper GetDepartmentAddEditSingleWrapper(DepartmentGetSingleArgs args)
        {
            DepartmentAddEditSingleWrapper returnItem = null;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this.BaseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonApplication));

            string serviceUrl = GenerateFullAddress(UrlSuffixGetDepartmentAddEditSingleWrapper);

            // HttpResponseMessage response = client.PostAsJsonAsync(serviceUrl, args).Result;
            HttpResponseMessage response = client.PostAsJsonAsync(serviceUrl, args).Result;

            this.DebugWriteLine(string.Empty);
            this.DebugWriteLine(response.ToString());
            this.DebugWriteLine(response.Content.ReadAsStringAsync().Result);
            this.DebugWriteLine(string.Empty);

            if (response.IsSuccessStatusCode)
            {
                Task<DepartmentAddEditSingleWrapper> wrap = response.Content.ReadAsAsync<DepartmentAddEditSingleWrapper>();
                if (null != wrap)
                {
                    returnItem = wrap.Result;
                }
                else
                {
                    throw new ArgumentNullException("Task<DepartmentAddEditSingleWrapper>.Result was null.  This was not expected.");
                }
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase + " " + response.RequestMessage);
            }

            return returnItem;
        }

        public Department AddDepartment(DepartmentAddEditArgs args)
        {
            Department returnItem = null;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this.BaseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonApplication));

            string serviceUrl = GenerateFullAddress(UrlSuffixAddDepartment);

            HttpResponseMessage response = client.PostAsJsonAsync(serviceUrl, args).Result;

            this.DebugWriteLine(string.Empty);
            this.DebugWriteLine(response.ToString());
            this.DebugWriteLine(response.Content.ReadAsStringAsync().Result);
            this.DebugWriteLine(string.Empty);

            if (response.IsSuccessStatusCode)
            {
                Task<Department> wrap = response.Content.ReadAsAsync<Department>();
                if (null != wrap)
                {
                    returnItem = wrap.Result;
                }
                else
                {
                    throw new ArgumentNullException("Task<Department>.Result was null.  This was not expected.");
                }
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase + " " + response.RequestMessage);
            }

            return returnItem;
        }

        public Department UpdateDepartment(DepartmentAddEditArgs args)
        {
            Department returnItem = null;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this.BaseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonApplication));

            string serviceUrl = GenerateFullAddress(UrlSuffixUpdateDepartment);

            HttpResponseMessage response = client.PostAsJsonAsync(serviceUrl, args).Result;

            this.DebugWriteLine(string.Empty);
            this.DebugWriteLine(response.ToString());
            this.DebugWriteLine(response.Content.ReadAsStringAsync().Result);
            this.DebugWriteLine(string.Empty);

            if (response.IsSuccessStatusCode)
            {
                Task<Department> wrap = response.Content.ReadAsAsync<Department>();
                if (null != wrap)
                {
                    returnItem = wrap.Result;
                }
                else
                {
                    throw new ArgumentNullException("Task<Department>.Result was null.  This was not expected.");
                }
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase + " " + response.RequestMessage);
            }

            return returnItem;
        }
    }
}
