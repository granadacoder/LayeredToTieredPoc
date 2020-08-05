
Short Version:

(1)
Open:
	\src\Solutions\MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Solution.sln

(2)
Run \SolutionItems\SqlScripts\Dept_Emp_DDL.sql.txt against a SqlServer database.
  (Easier path is to name the database "OrganizationDB")

(3)
Find all "MainDatabaseConnectionString" and fix the database connection strings.
  (Search for "OrganizationDB" to find all of the existing databases)

(4) (WebApi Path) (WebApi is less fickle then WCF fyi)
Set Multiple Setup Projects to (only):
MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.Host.csproj
and
MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.FunctionalTests.csproj

Start / Run the solution.

(5) (WCF Path)
Set Multiple Setup Projects to (only):
MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Wcf.Host.csproj
and
MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Wcf.FunctionalTests.csproj

Start / Run the solution.


Note, if you get a error:
endPointName='xxxxx'
The communication object, System.ServiceModel.Channels.ServiceChannel, cannot be used for communication because it is in the Faulted state.
You need to adjust 
	src\FunctionalTests.Wcf\CustomAppSettings.config
	(and make it ~~one of~~ the "Wcf.Host EndPoint Names" values listed in the same file)

Longer Version:


(A) No Services.  N-Layered.  Presentation Layer uses BusinessLogic Layer directly.
1.  Open the Solution.
2.  Set "MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.UnitTests.csproj" as the startup project.
3.  Open \MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.UnitTests\UnityConfiguration.config
4.  Note the lines:
	      <register type="IDepartmentManagerAlias" mapTo="DepartmentManagerNoWCFAlias"/>
5.  This is the "magic line" that points the Presentation-Layer to the BusinessLogic-Layer directly.  You can find the definitions for these 2 aliases in the same file.
6.  Explanation:  The presentation layer needs one version of the "IDepartmentManager" to execute.  Through Unity-Injection, it uses "MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.BusinessLogic.Managers.DepartmentManager"

(B) WCF Self-Hosted Service.  N-Tiered.  Presentation Layer uses Proxy to initiate communication with WCF-Service.
1.  Open \MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.UnitTests\UnityConfiguration.config.
2.  Change (or comment/uncomment existing lines) so that IDepartmentManagerAlias points to DepartmentManagerWithWCFAlias:
	<register type="IDepartmentManagerAlias" mapTo="DepartmentManagerWithWCFAlias"/>
	Note, you'll have to comment out any other "IDepartmentManagerAlias" entries in the same file.
3.  Right click the solution name and go to Solution-Properties.
4.  Set the start up projects to be multiple projects.
	"MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.UnitTests.csproj"
	and
	MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Wcf.Host.csproj
5.  Build and Run the solution.	
6.  Note that somewhere in the Console output, is the Department with Name of "DepartmentCreatedViaDepartmentWebApiBusinessServiceControllerTemp".
	This is an artificially induced object to quickly show that the MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.BusinessServices is being used.
7.  Now the presentation layer is using a proxy "DepartmentManagerClientProxy" in the project "MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Wcf.ClientProxies.csproj", that calls out the "Wcf.Host" which is self-hosting the WCF services.

8.  Explanation:  The presentation layer needs one version of the "IDepartmentManager" to execute.  Through Unity-Injection, it uses "MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Wcf.ClientProxies.Managers.DepartmentManagerClientProxy" which is a proxy to the WCF-Self-Hosted-Services.

10.  Optional instruction for "(B) WCF Self-Hosted Service" below this line.
11.	Open the file: (under the project "MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.UnitTests.csproj)
	\FunctionalTests.Wcf\WCFClient.config
12. Note the values:
	<endpoint name="NamedPipeEndPointName"
	<endpoint name="BasicHttpEndPointName"
	<endpoint name="JsonEndPointName"
	<endpoint name="WSHttpEndPointName"
	<endpoint name="TcpEndPointName"
13.  Open the file:
	\FunctionalTests.Wcf\CustomAppSettings.config
	For the ~value of the key "DefaultEndPointName", you can select of the above values (the "name" attribute).
14. Explanation:  The Wcf-Self-Host is exposing multiple endpoints for the same Service.  	
	

(C) WebApi Self-Hosted Service.  N-Tiered.  Presentation Layer uses Proxy to initiate communication with WebApi-Service.
1.  Set the start up projects to be multiple projects. (Make sure to un-start any other projects)
	"MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.FunctionalTests.WebApi.csproj"
	and
	MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.Host.csproj
2.  Open the file:
	\FunctionalTests.WebApi\UnityConfiguration.config
3. 	Note the lines:
	      <register type="IDepartmentManagerAlias" mapTo="DepartmentManagerWebApiProxyAlias"/>
4.  Also note how "bare" the UnityConfiguration.config is in the project.
5.  Build and Run.
6.  Note that somewhere in the Console output, is the Department with Name of "DepartmentCreatedViaDepartmentWebApiBusinessServiceControllerTemp".
	This is an artificially induced object to quickly show that the MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.BusinessServices is being used.

7.  Explanation:  The presentation layer needs one version of the "IDepartmentManager" to execute.  Through Unity-Injection, it uses "MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.ClientProxies.Managers.DepartmentManagerClientProxy" which is a proxy to the WebApi-Self-Hosted-Services.



(D) WebApi IIS-Hosted Service.  N-Tiered.  Presentation Layer uses Proxy to initiate communication with WebApi-Service.
1.	"MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.FunctionalTests.WebApi.csproj"
	and
	MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.IIS.Host.csproj
2.  Open the file:
	\FunctionalTests.WebApi\CustomAppSettings.config
3.  Comment out the line:
	<add key="WebApiBaseAddress" value="http://localhost:9000/" />
4.  Uncomment out the line:
	  <add key="WebApiBaseAddress" value="http://localhost:16899/" />
5.  This has the same results as "C WebApi Self-Hosted Service", but the Service is hosted in IIS (IIS-Express in dev mode) for the Service.

7.  Explanation:  The presentation layer needs one version of the "IDepartmentManager" to execute.  Through Unity-Injection, it uses "MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.WebApi.ClientProxies.Managers.DepartmentManagerClientProxy" which is a proxy to the WebApi-IIS-Hosted-Services.


(E) WCF IIS-Hosted Service.  N-Tiered.  Presentation Layer uses Proxy to initiate communication with WCF-Service.
1.  This part will not run out of the box.
2.	MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Wcf.IIS.Host.csproj must be setup as a IIS-Application.
3.  If you feel like experimenting...then
4.  Set the start up project to be:
	MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Wcf.IIS.Host.csproj 
	and
	"MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.UnitTests.csproj"
5.	Open the file: (Under the project : MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.UnitTests.csproj)
	\FunctionalTests.Wcf\WCFClient.config
10. Note the values:
	<endpoint name="IISBasicHttpEndPointName"
	<endpoint name="IISWSHttpEndPointName"
	<endpoint name="IISJsonEndPointName"
	<endpoint name="IISTcpEndPointName"
11.  Open the file:
	\FunctionalTests.Wcf\CustomAppSettings.config
12.	For the ~value of the key "DefaultEndPointName", you can select of the above values (the "name" attribute). (IISTcpEndPointName requires advanced IIS setup).

13.  Explanation:  The presentation layer needs one version of the "IDepartmentManager" to execute.  Through Unity-Injection, it uses "MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Wcf.ClientProxies.Managers.DepartmentManagerClientProxy" which is a proxy to the WCF-IIS-Hosted-Services.


(F) Data-Store.
1.  Out of the box, all data is coming from a Mock object:
	MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.Data.MockDomainData.DomainData.DepartmentData
2.  To enable a real database:
3.  Find the script "Dept_Emp_DDL.sql.txt" under "Solution Items".
4.  Create your own database, and run this script to create 2 tables.  Name your database "OrganizationDB" if you want to minimize config changes.
5.	Find all "ExternalConnectionStrings.config" files in the solution and change the Connection String to match your Server\Instance\DatabaseName.
	Note, there are 5 of these files.
6.  Search for the string "<register type="IDepartmentDataAlias" mapTo="MockDepartmentDataAlias"/>" 
	(no quotes)
7.  Comment out 
		<register type="IDepartmentDataAlias" mapTo="MockDepartmentDataAlias"/>
	and uncomment
		<register type="IDepartmentDataAlias" mapTo="DepartmentDataAlias"/>
8.  This is basically swapping the Mock for the Real version.


		