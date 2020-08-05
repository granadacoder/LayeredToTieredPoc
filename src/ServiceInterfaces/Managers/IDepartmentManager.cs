namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.ServiceInterfaces.Managers
{
    using System.ServiceModel;
    using System.ServiceModel.Web;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Args.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Compositions.DepartmentCentric;

    [ServiceContract]
    public interface IDepartmentManager
    {
        [OperationContract]
        [WebInvoke(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)
        ]
        [FaultContract(typeof(ExceptionDetail))]
        DepartmentAllWrapper GetDepartmentAllWrapper();

        [OperationContract]
        [WebInvoke(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)
        ]
        [FaultContract(typeof(ExceptionDetail))]
        DepartmentAddEditSingleWrapper GetDepartmentAddEditSingleWrapper(DepartmentGetSingleArgs args);

        [OperationContract]
        [WebInvoke(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)
        ]
        [FaultContract(typeof(ExceptionDetail))]
        Department AddDepartment(DepartmentAddEditArgs args);

        [OperationContract]
        [WebInvoke(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)
        ]
        [FaultContract(typeof(ExceptionDetail))]
        Department UpdateDepartment(DepartmentAddEditArgs args);
    }
}
