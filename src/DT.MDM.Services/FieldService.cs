using DT.MDM.Models;
using DT.MDM.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DT.MDM.Services
{
    public class FieldService
    {
        private readonly FieldRepository _repo;

        public FieldService(FieldRepository fieldRepository)
        {
            _repo = fieldRepository;
        }

        public IQueryable<Field> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<Field> GetByIdAsync(int id)
        {
            Field field = await _repo.GetByIdAsync(id);

            return field;
        }

        public async Task<Field> AddAsync(Field field, string userName)
        {
            DateTime curDate = DateTime.Now;

            field.Created = curDate;
            field.CreatedBy = userName;
            field.Modified = curDate;
            field.ModifiedBy = userName;

            Field newField = await _repo.AddAsync(field);

            return newField;
        }

        public async Task<Field> UpdateAsync(Field field, string userName)
        {
            DateTime curDate = DateTime.Now;

            field.Modified = curDate;
            field.ModifiedBy = userName;

            Field updField = await _repo.UpdateAsync(field);

            return updField;
        }

        public async Task<Field> DeleteAsync(Field field)
        {
            Field delField = await _repo.DeleteAsync(field);

            return delField;
        }
    }
}
