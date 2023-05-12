using ConnectDbAspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace ConnectDbAspNet.Pages
{
    public class StudentsModel : PageModel
    {
        private readonly SchoolContext _context;

        public StudentsModel(SchoolContext context)
        {
            _context = context;
        }

        public List<Student> Students { get; set; }
        public void OnGet()
        {
            Students = _context.Students.ToList();
        }

        public ActionResult OnPostDelete(int id)
        {
            Student studentToDelete = _context.Students.Find(id);
            _context.Remove(studentToDelete);
            _context.SaveChanges();

            return RedirectToPage("/Students");
        }
    }
}
