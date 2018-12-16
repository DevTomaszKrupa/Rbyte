Mvc:
1. Required software:
	1.1 Framework .net core (version 2.2)
		https://dotnet.microsoft.com/download
	1.2 Node engine with npm (newest version)
		https://nodejs.org/en/
	1.3 Gulp (globally in system)
		- go to cmd
		- call command 'npm install gulp -g'

2. Required files
	Create two files in main directory of Rbyte.Mvc project:
		- appsettings.Development.json
		- connectionString.Development.json  
	analogously to existing original files:
		- appsettings.json
		- connectionString.json
  
  Fill parameters between $$ (in files with '.Development' in name, do not edit original files!)
  Example:
  - in appsettings.Development.json file:
		$$DATABASE$$ -> MySql
  - in connectionString.Development.json file:
		$$SERVER_NAME$$ -> localhost
		$$DATABASE_NAME$$ -> Rbyte
		$$USER_NAME$$ -> admin
		$$USER_PASSWORD$$ -> admin
	
3. Build solution
	In Visual Studio:
		a) Right click on 'Rbyte.Mvc' project and 'Set as StartUp Project'
		b) Build -> Build Solution (or Ctrl + Shift + B)
	
4. Create database
	In Visual Studio:
		a) Open Package Manager Console (Tools -> NuGet Package Manager -> Package Manager Console)
		b) Set 'Default project' as 'Rbyte.Mvc'
		c) Call command 'Update-Database -Context $$ContextName$$'
			where $$ContextName$$ is:
			- 'PostgreSqlRbyteContext' for PostgreSql
			- 'MySqlRbyteContext' for MySql
			- 'MSSqlRbyteContext' for MSSql
	In command line client:
		a) navigate to 'Rbyte.Mvc' main directory
		b) call command 'dotnet ef database update -c $$ContextName$$'
			where $$ContextName$$ is:
			- 'PostgreSqlRbyteContext' for PostgreSql
			- 'MySqlRbyteContext' for MySql
			- 'MSSqlRbyteContext' for MSSql
