using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IProjectRepository : IAsyncRepository<Project>
    {
        //Task<CreateProject> AddProject(CreateProject project);
    }
}
