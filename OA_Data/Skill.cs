using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Data
{
    public class Skill : BaseEntity
    {
        [Required]
        public string skillName { get; set; }
    }
}
