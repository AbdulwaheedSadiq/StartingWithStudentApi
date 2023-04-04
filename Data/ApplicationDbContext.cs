using Microsoft.EntityFrameworkCore;
using StudentClass1;
using Students.Models;

namespace Students.Data{
    public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
      
    }
     public DbSet <Student> tblStudents { get; set; } 
     public DbSet  <StudentClass> tblClasses { get; set; }
}
}