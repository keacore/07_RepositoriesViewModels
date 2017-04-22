using System.Collections.Generic;
using ConsoleApplication.Models.Entities;

namespace ConsoleApplication.Models.Repositories
{
    interface IStudentRepository
    {
        // basicc CRUD for Student
        void Save(Student student);
        Student Get(int id);
        IEnumerable<Student> GetAll();
        void Update(Student student);
        void Delete(int id);
    }
}
