using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OA_Data;
using OA_Service.Skill_Service;
using OA_Service.Student_Service;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        //public IActionResult Index()
        //{
        //    IEnumerable<Student> students = _student.GetAllStudents();
        //    return View(students);
        //}

        public IActionResult Index(string searchString)
        {
            var students = _student.GetAllStudents();
            if (!string.IsNullOrEmpty(searchString))
            {
                //data = data.Where(x => x.Name == search).OrderBy(x => x.DisplayOrder).ToList();
                students = students.Where(x => x.Name.Contains(searchString)).ToList();
            }
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
            //if (ModelState.IsValid)
            {
                _student.InsertStudent(student);
                return RedirectToAction("Index");
            }

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
        public IActionResult Delete(int id)
        {
            _student.DeleteStudent(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            Student student = _student.StudentDetails(id);
            return View(student);
        }
    }
}
