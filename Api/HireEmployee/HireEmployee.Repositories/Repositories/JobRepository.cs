using HireEmployee.Entities;
using HireEmployee.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireEmployee.Repositories.Repositories
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        public JobRepository(HireEmployeeDbContext dbContext) : base(dbContext)
        {
        }
    }
}
