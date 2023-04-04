using System;

namespace Students.ViewModels{

    public class StudentResponse{
                public int Id { get; set; }
        public string FullName { get; set; }

        public string Gender { get; set; }

        public DateTime RegDate { get; set; }
        public string ClassName { get; set; }
        
    }
}