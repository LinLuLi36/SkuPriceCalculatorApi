# SkuPriceCalculatorApi

The application is built by using "ASP.NET Core Web API" project template in Visual Studio 2019.
All promotion modules are included in the PromotionTypes.cs file located in https://github.com/LinLuLi36/SkuPriceCalculatorApi/tree/master/SkuPriceCalculatorApi/Module

The "HttpGet" method in PriceCalculationController.cs takes a string parameter which is a collction of all "SKUId,Amount"'s separated by ";". 
An example of the string input can be "A,5;B,5;C,1;D,1"  

A docker file is created, so the application is ready to be publish to Azure Docker Container Registery. 
Otherwise It can also be published to Azure by using Azure web app service.

An unit test project is created. The test tests the flow of the price calculation 
