using System;
using System.ComponentModel.DataAnnotations;
using StudentClass1;

namespace Students.Models{

   public class Student{

    public Student(){}
        public int Id { get; set; }

        [Required]
        [MaxLength]
        public string FullName { get; set; }

        public string Gender { get; set; }

        public DateTime RegDate { get; set; }

        public int StudentClassId { get; set; }

        public StudentClass StudentClass { get; set; }
    }
}