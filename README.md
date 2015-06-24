# pb-programming-assignment
This is Programming assignment to check for programming skills

## Project Setup
### Create Database
1. Set the connection string as need acording to your sql server instalation by default is: 

    add name="AccountManagerContext" providerName="System.Data.SqlClient" connectionString="Server=.;Database=PTAssigment;Integrated Security=True;" 
    
you can find it on the web config of the web api project 

2. Right click the solution and click properties on Start up project ensure that is set to Single Startup project and csv-import.webapi is the selected project 

3. Once you got your connection string properly configured and the web api project as start up project got to tools -> Nutget package manager -> package manager console on the console ensure that the default project is csv-import.datalayer and then type update-database and enter in the console 

4. If everything was ok, you should now have your database created

### Running the project
Since the web api and the client are on diferrent projects you will need to run both so: 

1. Right click your solution again and click properties, click on Multiple startup projects and set action start to csv-import.client and cs-import.webapi 

2.You can hit start now and the application should be ready for use

### Troubleshooting
1. Check in what port you web api is running if it is running on a different port than 23730 you will need to change the web properties of the web api project or in csv-import.client and open common -> common.services.js file and change serverPath to whatever localhost:port that you are using for web api
