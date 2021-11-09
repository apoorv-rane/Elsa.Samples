using System;
using System.ComponentModel.DataAnnotations;

namespace HireEmployee.Entities
{
    public class Job
    {
        [Key]
        public Guid Id { get; set; }
        public string Designation { get; set; }
        public string Skills { get; set; }
        public string Salary { get; set; }
        public int Experience { get; set; }
    }
}
