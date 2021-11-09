using HireEmployee.Entities;
using HireEmployee.IRepositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireEmployee.Repositories.Repositories
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(HireEmployeeDbContext dbContext) : base(dbContext)
        {
        }
    }
}
