# ExpenseTracker
> Application for tracking your monthly expenses.

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Features](#features)

## General info
ExpenseTracker is a ASP.NET Core MVC app that enables tracking expenses of every month. User adds expenses to detailed category, gives name, data and amount.
Planning budget is possible for every month - if it is planned, there are statement of planned and spent money. Thanks to it, user can see how much is meant to be used and compare the months.
Every detailed category is assigned to main category. User can manage these categories in order to preferences. ExpenseTracker is built using Clean Architecture and Service-Repository pattern.

## Technologies
* .NET Core 3.1
* ASP.NET Core MVC
* Dependency Injection
* Entity Framework Core 3.1.6
* Automapper 10.1.1
* LINQ

According to Clean Architecture, the application consists of domain, application, infrastructure and UI project.
The first project has all models and repository interfaces, in application there are services and ViewModels.
The infrastructure layer has repositories and UI contains controllers and views.
## Features

* Adding exepenses
* Default categories after registration
* Management of detailed and main categories
* Statement of planned and spent money in both categories
* Possibility to track all expenses per month
