using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireEmployee.Entities
{
    public class Candidate
    {
        [Key]
        public Guid Id { get; set; }
        public Guid JobId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Skill { get; set; }
        public int Experience { get; set; }
        public string Resume { get; set; }
        public int ExpectedSalary { get; set; }
    }
}
