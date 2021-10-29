using DT.MDM.Models;
using DT.MDM.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DT.MDM.Services
{
    public class ResourceService
    {
        private readonly ResourceRepository _repo;

        public ResourceService(ResourceRepository resourceRepository)
        {
            _repo = resourceRepository;
        }

        public IQueryable<Resource> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<Resource> GetByIdAsync(int id)
        {
            Resource resource = await _repo.GetByIdAsync(id);

            return resource;
        }

        public async Task<Resource> AddAsync(Resource resource, string userName)
        {
            DateTime curDate = DateTime.Now;

            resource.Created = curDate;
            resource.CreatedBy = userName;
            resource.Modified = curDate;
            resource.ModifiedBy = userName;

            Resource newResource = await _repo.AddAsync(resource);

            return newResource;
        }

        public async Task<Resource> UpdateAsync(Resource resource, string userName)
        {
            DateTime curDate = DateTime.Now;

            resource.Modified = curDate;
            resource.ModifiedBy = userName;

            Resource updResource = await _repo.UpdateAsync(resource);

            return updResource;
        }

        public async Task<Resource> DeleteAsync(Resource resource)
        {
            Resource delResource = await _repo.DeleteAsync(resource);

            return delResource;
        }
    }
}
