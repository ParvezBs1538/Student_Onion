using OA_Data;

namespace OA_Service.Skill_Service
{
    public interface ISkillService
    {
        void InsertSkill(Skill entity);
        void UpdateSkill(Skill entity);
        void DeleteSkill(int id);
        Skill SkillDetails(int id);
        Skill GetBySkillId(int id);
        IEnumerable<Skill> GetAllSkills();
        void SaveChanges();
        bool SkillNameExists(string entity);
    }
}
