using System.Collections.Generic;
using Students.Models;

namespace StudentClass1{
   public class StudentClass{
        public int Id { get; set; }
        public string  className { get; set; }

        public List<Student> Student { get; set; }
    }
}