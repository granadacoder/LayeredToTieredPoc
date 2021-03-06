namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.FunctionalTests.WebApi
{
    using System;
    using System.Linq;

    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Args.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.BusinessObjects;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Collections;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Domain.Compositions.DepartmentCentric;
    using MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.ServiceInterfaces.Managers;

    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                System.Threading.Thread.Sleep(1000);

                UnityContainer container = new UnityContainer();
                container.LoadConfiguration();

                IDepartmentManager man = container.Resolve<IDepartmentManager>();

                DepartmentAllWrapper deptAllWrapper = man.GetDepartmentAllWrapper();
                ShowDepartmentAllWrapper(deptAllWrapper);

                if (null != deptAllWrapper)
                {
                    if (null != deptAllWrapper.Departments)
                    {
                        Department foundDept1 = deptAllWrapper.Departments.FirstOrDefault();
                        if (null != foundDept1)
                        {
                            DepartmentGetSingleArgs args1 = new DepartmentGetSingleArgs();
                            args1.DepartmentSurrogateKey = foundDept1.DepartmentUUID;
                            DepartmentAddEditSingleWrapper singleWrapper = man.GetDepartmentAddEditSingleWrapper(args1);
                            ShowDepartmentAddEditSingleWrapper(singleWrapper);
                        }
                    }
                }

                DepartmentAddEditArgs newArgs = new DepartmentAddEditArgs();
                newArgs.DepartmentSurrogateKey = Guid.NewGuid();
                newArgs.DepartmentName = "New_WebApi_Department:" + Guid.NewGuid().ToString("N");
                newArgs.CreateDate = DateTime.Now;
                Department newDept = man.AddDepartment(newArgs);
                ShowDepartment(newDept);

                if (null != newArgs)
                {
                    DepartmentAddEditArgs updateArgs = new DepartmentAddEditArgs() { DepartmentSurrogateKey = newArgs.DepartmentSurrogateKey, DepartmentName = "Update+" + newArgs.DepartmentName, CreateDate = DateTime.Now };
                    Department dept2 = man.UpdateDepartment(updateArgs);
                    ShowDepartment(dept2);
                    Console.WriteLine(string.Empty);
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
            finally
            {
                Console.WriteLine("Press ENTER to Exit");
                Console.ReadLine();
            }
        }

        private static void ShowDepartmentAddEditSingleWrapper(DepartmentAddEditSingleWrapper wrap)
        {
            if (null != wrap)
            {
                if (null != wrap.PrimaryDepartment)
                {
                    ShowDepartment(wrap.PrimaryDepartment);
                }
            }
        }

        private static void ShowDepartmentAllWrapper(DepartmentAllWrapper wrap)
        {
            if (null != wrap)
            {
                ShowDepartmentCollection(wrap.Departments);
            }
        }

        private static void ShowDepartmentCollection(DepartmentCollection coll)
        {
            if (null != coll)
            {
                coll.ForEach(d => Console.WriteLine(d.DepartmentName));
            }
        }

        private static void ShowDepartment(Department dept)
        {
            if (null != dept)
            {
                DepartmentCollection coll = new DepartmentCollection();
                coll.Add(dept);
                ShowDepartmentCollection(coll);
            }
        }
    }
}
