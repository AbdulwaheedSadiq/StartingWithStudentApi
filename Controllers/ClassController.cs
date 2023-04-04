using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StudentClass1;
using Students.Data;
using Students.ViewModels;

namespace StudentClassController.Controllers{

[ApiController]
[Route("Api/StudentClass")]
    public class ClassController : ControllerBase{
        private readonly ApplicationDbContext repo;

     
        public ClassController(ApplicationDbContext dbContext){
            repo = dbContext;
        }


        [HttpGet]
        public ActionResult<List<ClassResponse>> getAllClasses(){
            List<StudentClass> classes = repo.tblClasses.ToList();


        List<ClassResponse> resp = new List<ClassResponse>();
            foreach(StudentClass s in classes){
            ClassResponse response = new ClassResponse();
            response.Id= s.Id;
            response.className= s.className;
            resp.Add(response);
            }

            return Ok(resp);
        }


        [HttpPost]
        public ActionResult<ClassResponse> insert(ClassRequest c){
            try{



            
                // List<StudentClass> cls =repo.tblClasses.Where(x=>x.className == c.ClassName ).ToList();
                // if(cls.Count <0){
           
            StudentClass student = new StudentClass();
            student.className = c.ClassName;

            repo.tblClasses.Add(student);
            repo.SaveChanges();


            ClassResponse response = new ClassResponse();
            response.Id= student.Id;
            response.className= student.className;

            return Ok(response);
                // }
                // else{
                //     return BadRequest("Class Already Exists");
                // }
            }catch (Exception)
            {
              return StatusCode(500,"something is Wrong");
            }
 
        }
        
    }
}