# 07 Repositories, ViewModels, Partial Views, Boostrap Grid System

To day we will work with a range of concepts used in ASP.NET MVC Web Development

We will look at:

* **Repositories**, which is a tecnique to achieve low coupling between the Controller classes and the DbContext class.
* **VievModels**, which is a model like or entity classes, but it is designed to serve the right data to our views.
* **_Layout, _ViewStart and Partial Views**, which deals with reuse of hmtl and razor code in our views
* **Bootstrap Grid System**, which is an important part of Boostrap and is very usefull when designing the frontend of your application.


## Repositories
<img src="https://github.com/keacore/07_RepositoriesViewModels/blob/master/Materials/img/Repository.png" width="300">


## ViewModels
<img src="https://github.com/keacore/07_RepositoriesViewModels/blob/master/Materials/img/ViewModel.png" width="400">


## Layout
### _Layout.cshtml
<img src="https://github.com/keacore/07_RepositoriesViewModels/blob/master/Materials/img/_Layout.png" width="400">
### _ViewStart.cshtml

````CSharp
    @{
         Layout = "~/Views/Shared/_Layout.cshtml";
    }
````   
