using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Data
{
    public class Student : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int skillid { get; set; }
        [ForeignKey("skillid")]
        public Skill Skill { get; set; }
    }
}
