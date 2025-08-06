using System.Globalization;

namespace UserAuthtication.Models
{
    public class Course
    {
        public int Id { get; set; }
        public String CourseName { get; set; }
        public int CreditHours { get; set; }
        public string  ModuleLeader { get; set; }
        public ICollection<Student> Students { get; set; } = []; 
    }
}
