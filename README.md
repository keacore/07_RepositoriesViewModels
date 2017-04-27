# 07 Repositories, ViewModels, Partial Views, Boostrap Grid System

To day we will work with a range of concepts used in ASP.NET MVC Web Development

We will look at:

* **Repositories**, which is a tecnique to achieve low coupling between the Controller classes and the DbContext class.
* **VievModels**, which is a model like or entity classes, but it is designed to serve the right data to our views.
* **_Layout, _ViewStart and Partial Views**, which deals with reuse of hmtl and razor code in our views
* **Bootstrap Grid System**, which is an important part of Boostrap and is very usefull when designing the frontend of your application.


## Repositories
<img src="https://github.com/keacore/07_RepositoriesViewModels/blob/master/Materials/img/Repository.png" width="300">

````CSharp
    public interface IStudentRepository
    {
        // basicc CRUD for Student
        void Save(Student student);
        Student Get(int id);
        IEnumerable<Student> GetAll();
        void Update(Student student);
        void Delete(int id);
    }
````     

````CSharp
    public class StudentRepository : IStudentRepository
    {
        private MyDbContext _db;
        private DbSet<Student> _students;
        
        public StudentRepository(MyDbContext db)
        {
            _db = db;
            _students = db.Students;
        }
        public void Delete(int id)
        {
             throw new NotImplementedException();
        }

        public Student Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
             throw new NotImplementedException();
        }

        public void Save(Student student)
        {
             throw new NotImplementedException();
        }

        public void Update(Student student)
        {
             throw new NotImplementedException();
        }
    }
}
    
````    
    
    
    

````CSharp    
    public class StudentController : Controller
    {
        // Tightly Coupled
        //MyDbContext db = new MyDbContext();
        //private IStudentRepository studentRepository = new StudentRepository(new MyDbContext());

        // Instead Dependency Inject
        private IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        // Index
        [HttpGet]
        public IActionResult Index()
        { 
            IEnumerable<Student> students = studentRepository.GetAll();
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       
       ...
````    

In Startup.cs

````CSharp

    public void ConfigureServices(IServiceCollection servises)
    {
            servises.AddMvc();
            // Register the Service so it can be injected in the Controller when an object of that is made
            servises.AddScoped<IStudentRepository, StudentRepository>();
    }

````





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
        public DateTime EnrollmenDate { get; set;
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
        
        // Navigation prop
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
````    

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

*_Layout.cshtml*
````Razor  
<!DOCTYPE html>
<html lang="en">
    <head>
        <title>@ViewBag.Title</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    </head>
    <body class="container" style="margin-top: 40px">
        <div class="jumbotron">
            <h1>@ViewBag.Title</h1>
        </div>
            @RenderBody() <!-- All my code from the views will be placed here -->
    </body>
</html>
````   


### _ViewStart.cshtml      
    
````CSharp
    @{
         Layout = "~/Views/Shared/_Layout.cshtml";
    }
````   

### Partial View
<img src="https://github.com/keacore/07_RepositoriesViewModels/blob/master/Materials/img/Partial.png" width="400"> 
