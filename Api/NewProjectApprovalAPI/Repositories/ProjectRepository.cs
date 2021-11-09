using Entities;
using IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectDbContext dbContext) : base(dbContext)
        {
        }

        //public Task<CreateProject> AddProject(CreateProject project)
        //{
        //    throw new NotImplementedException();
        //}
    } 
}
