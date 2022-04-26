Write-Host "Run Automation Test ..."
dotnet vstest .\todos-tests\bin\Debug\netcoreapp3.1\todos.tests.dll --TestCaseFilter:"TestCategory=e2eTest" 