using ConnectDbAspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace ConnectDbAspNet.Pages
{
    public class UpdateModel : PageModel
    {
        private readonly SchoolContext _context;

        public UpdateModel(SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public void OnGet(int id)
        {
            Student = _context.Students.Find(id);
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Student updatedStudent = _context.Students.Find(Student.Id);

                updatedStudent.Name = Student.Name;
                updatedStudent.EnrollmentDate = Student.EnrollmentDate;

                _context.SaveChanges();
                return RedirectToPage("/Students");
            }
            return Page();
        }
    }
}
