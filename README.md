# 07 Repositories, ViewModels, Partial Views, Boostrap Grid System

To day we will work with a range of concepts used in ASP.NET MVC Web Development

We will look at:

* **Repositories**, which is a tecnique to achieve low coupling between the Controller classes and the DbContext class.
* **VievModels**, which is a model like or entity classes, but it is designed to serve the right data to our views.
* **_Layout, _ViewStart and Partial Views**, which deals with reuse of hmtl and razor code in our views
* **Bootstrap Grid System**, which is an important part of Boostrap and is very usefull when designing the frontend of your application.


## Repositories
<img src="https://github.com/keacore/07_RepositoriesViewModels/blob/master/Materials/img/Repository.png" width="300">

## Query related Database Tables
<img src="https://github.com/keacore/04_Entity_Framework/blob/master/Materials/data-model-diagram.png" width="500">

````CSharp
    
    public class Student
    {
        public int StudentID { get; set; }
        
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [DataTypeAttribute(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmenDate { get; set; }
       
        public int Age { get; set; }

        // Navigation prop
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
````   

````CSharp    
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }

`````     
````CSharp    
    
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public int Grade { get; set; }

        // Navigation prop
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
````    





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

### Partial View
<img src="https://github.com/keacore/07_RepositoriesViewModels/blob/master/Materials/img/Partial.png" width="400"> 
