# First run
	1.	Create files (copy file without transformation and fill parameters between $$):
			'connectionStrings.Development.json'
			'appsettings.Development.json'
	2.	Navigate to '..\Rbyte\Src\Presentation\Rbyte.Angular\rbyte>' and call command 'npm install'
	3.	Set Rbyte.Api project as StartUp Project
	4.	Open Package Manager Console, Set Default Project as 'Rbyte.Api' and call command 'Update-Database -Context $$HERE_PUT_CONTEXT_NAME$$'

# Running solution
	(Angular app)
	1.	Navigate to ..\Rbyte\Src\Presentation\Rbyte.Angular\rbyte>
	2.	Call command 'ng serve'

	(.Net Core app)
	1.	Run Rbyte.Api in VisualStudio
		or
		Navigate to ..\Rbyte\Src\Api\Rbyte.Api and call 'dotnet run'
