using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OA_Data;
using OA_Service;

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
            //ViewBag.getskill = _skill.GetAllSkills();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _student.InsertStudent(student);
                return RedirectToAction("Index");
            }

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
