dotnet restore  /wiki
dotnet build
dotnet run

в случае ошибок:
dotnet add package Selenium.WebDriver
dotnet add package Selenium.WebDriver.ChromeDriver
//////////////////////////////////////////////////////////////
-labr 3
Разрешите запуск скриптов, выполнив команду:
Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser

установка scoop:
irm get.scoop.sh | iex

установка allure:
scoop install allure
