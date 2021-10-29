using DT.MDM.DAL;
using DT.MDM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DT.MDM.Repositories
{
    public class ResourceRepository
    {
        private MDMContext _context = null;

        public ResourceRepository(MDMContext mdmContext)
        {
            _context = mdmContext;
        }

        /// <summary>
        /// Get all resources
        /// </summary>
        /// <returns></returns>
        public IQueryable<Resource> GetAll()
        {
            return _context.Resources;
        }

        /// <summary>
        /// Get a resource for a specific id asynchronously
        /// </summary>
        /// <param name="id">The id of the resource</param>
        /// <returns>The resource for that id</returns>
        public async Task<Resource> GetByIdAsync(int id)
        {
            return await _context.Resources.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Resource> AddAsync(Resource resource)
        {
            EntityEntry<Resource> entityEntry = _context.Resources.Add(resource);

            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<Resource> UpdateAsync(Resource resource)
        {
            EntityEntry<Resource> entityEntry = _context.Resources.Update(resource);

            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<Resource> DeleteAsync(Resource resource)
        {
            EntityEntry<Resource> entityEntry = _context.Resources.Remove(resource);

            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
