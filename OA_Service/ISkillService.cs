using OA_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service
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
    }
}
