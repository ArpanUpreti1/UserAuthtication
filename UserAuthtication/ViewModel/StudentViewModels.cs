using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace UserAuthtication.ViewModel
{
    public class StudentViewModels
    {

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        public List<SelectListItem> Courses { get; set; } = new List<SelectListItem>();


    }
}
