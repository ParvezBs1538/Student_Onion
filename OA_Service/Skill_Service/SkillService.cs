using OA_Data;
using OA_Repository;

namespace OA_Service.Skill_Service
{
    public class SkillService : ISkillService
    {
        private IRepository<Skill> db;
        public SkillService(IRepository<Skill> db)
        {
            this.db = db;
        }

        public void DeleteSkill(int id)
        {
            Skill skill = GetBySkillId(id);
            db.Delete(skill);
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return db.GetAll();
        }

        public Skill GetBySkillId(int id)
        {
            return db.GetById(id);
        }

        public void InsertSkill(Skill entity)
        {
            db.Insert(entity);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public Skill SkillDetails(int id)
        {
            return GetBySkillId(id);
        }

        public void UpdateSkill(Skill entity)
        {
            db.Update(entity);
        }
    }
}
