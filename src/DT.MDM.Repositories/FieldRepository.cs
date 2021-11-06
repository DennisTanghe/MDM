using DT.MDM.DAL;
using DT.MDM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DT.MDM.Repositories
{
    public class FieldRepository
    {
        private MDMContext _context = null;

        public FieldRepository(MDMContext mdmContext)
        {
            _context = mdmContext;
        }

        /// <summary>
        /// Get all fields
        /// </summary>
        /// <returns></returns>
        public IQueryable<Field> GetAll()
        {
            return _context.Fields;
        }

        /// <summary>
        /// Get a field for a specific id asynchronously
        /// </summary>
        /// <param name="id">The id of the field</param>
        /// <returns>The field for that id</returns>
        public async Task<Field> GetByIdAsync(int id)
        {
            return await _context.Fields.FirstOrDefaultAsync(r => r.Id == id);
        }

        /// <summary>
        /// Add a new field
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public async Task<Field> AddAsync(Field field)
        {
            EntityEntry<Field> entityEntry = _context.Fields.Add(field);

            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        /// <summary>
        /// Update existing field
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public async Task<Field> UpdateAsync(Field field)
        {
            EntityEntry<Field> entityEntry = _context.Fields.Update(field);

            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        /// <summary>
        /// Deletes a field
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public async Task<Field> DeleteAsync(Field field)
        {
            EntityEntry<Field> entityEntry = _context.Fields.Remove(field);

            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
