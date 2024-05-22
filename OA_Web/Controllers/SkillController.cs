using Microsoft.AspNetCore.Mvc;
using OA_Data;
using OA_Service.Skill_Service;


namespace OA_Web.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillService _skill;
        public SkillController(ISkillService skill)
        {
            _skill = skill;
        }

        public IActionResult Index()
        {
            IEnumerable<Skill> skill = _skill.GetAllSkills();
            return View(skill);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Skill skill)
        {
            if (_skill.SkillNameExists(skill.skillName))
            {
                ModelState.AddModelError("SkillName", "Skill name already exists.");
            }

            if (ModelState.IsValid)
            {
                _skill.InsertSkill(skill);
                return RedirectToAction("Index");
            }
            return View(skill);
        }
        public IActionResult Edit(int id)
        {
            Skill skill = _skill.GetBySkillId(id);
            return View(skill);
        }
        [HttpPost]
        public IActionResult Edit(Skill skill)
        {
            if (ModelState.IsValid)
            {
                _skill.UpdateSkill(skill);
                return RedirectToAction("Index");
            }
            return View(skill);
        }
        public IActionResult Details(int id)
        {
            Skill skill = _skill.SkillDetails(id);
            return View(skill);
        }
        public IActionResult Delete(int id)
        {
            Skill skill = _skill.GetBySkillId(id);
            return View(skill);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            _skill.DeleteSkill(id);
            return RedirectToAction("Index");
        }
    }
}
