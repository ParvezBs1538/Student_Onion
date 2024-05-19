using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Data
{
    public class Student : BaseEntity
    {
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public int skillid { get; set; }
        [ForeignKey("skillid")]
        public Skill Skill { get; set; }
    }
}
