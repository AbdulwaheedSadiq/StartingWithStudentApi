using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.Data;
using Students.Models;
using Students.ViewModels;

namespace StudentController.Controller{
[ApiController]
[Route("Api/Students")]

    public class StudentController : ControllerBase{

        private readonly ApplicationDbContext repo;
       public StudentController(ApplicationDbContext context)
       {
        repo = context;
       } 


        [HttpGet]
       public ActionResult<List<StudentResponse>> GetAllStudent(){

        List<Student> st = repo.tblStudents
        .Include(x=>x.StudentClass)
        .ToList();

        List<StudentResponse> response = new List<StudentResponse>();

        foreach(Student s in st){
            StudentResponse std = new StudentResponse();
            std.Id = s.Id   ;
            std.FullName=s.FullName;
            std.RegDate = s.RegDate;
            std.Gender  = s.Gender;
            std.ClassName = s.StudentClass.className;
            response.Add(std);
        }


        return Ok(response);

       }

          [HttpGet("{id}")]
       public ActionResult<Student> Getstudent(int id){
            try{
                var student = repo.tblStudents.FirstOrDefault(x=> x.Id == id);
                if(student == null){
                    return StatusCode(404,"Student Not Found");
                }
                return student;
            }catch(Exception e){
                return StatusCode(500,"Some Thing Is Wrong "+e);
            }

       }

       [HttpPost]
        public ActionResult<Student> CreateStudent(Student s){

            Student st = new Student();
            st= s;
            repo.tblStudents.Add(st);
            repo.SaveChanges();

            return Ok(st)
            ;
        }

        [HttpPut("{id:int}")]
        public ActionResult<Student> updateStudent(int id, Student student)
        {
            try{
                var st = repo.tblStudents.FirstOrDefault(x => x.Id == id);

                if (st == null){
                    return(StatusCode(404,"User Not Found"));
                }

                st.FullName = student.FullName;
                st.Gender = student.Gender;
                st.RegDate = student.RegDate;

               repo.Entry(st).State = EntityState.Modified;
                repo.SaveChanges();

                }catch(Exception ex){
                    return StatusCode(500,"Kuna Error");
                }
                return Ok(student);
        }

        [HttpDelete("{id}")]
        public ActionResult<string> deleteUser(int id){
            try{
                var user = repo.tblStudents.FirstOrDefault(x=>x.Id == id);
                if (user == null){
                    return StatusCode(404,"user not found");
                }
                repo.Entry(user).State = EntityState.Deleted;
                repo.SaveChanges();
            }
            catch(Exception e){
                return StatusCode(500,e);
            }
            return "deleted";
        }

    }
}