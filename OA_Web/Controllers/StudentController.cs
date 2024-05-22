using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OA_Data;
using OA_Service.Skill_Service;
using OA_Service.Student_Service;

namespace OA_Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _student;
        private readonly ISkillService _skill;

        public StudentController(IStudentService student, ISkillService skill)
        {
            _student = student;
            _skill = skill;
        }

        public IActionResult Index()
        {
            IEnumerable<Student> students = _student.GetAllStudents();
            return View(students);
        }

        public IActionResult Create()
        {
            ViewBag.Skills = _skill.GetAllSkills()
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.skillName
                })
                .ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _student.InsertStudent(student);
            return RedirectToAction("Index");

            // Populate ViewBag.Skills again to ensure the dropdown is available when the view is returned
            ViewBag.Skills = _skill.GetAllSkills()
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.skillName
                })
                .ToList();

            return View(student);
        }
    }
}
