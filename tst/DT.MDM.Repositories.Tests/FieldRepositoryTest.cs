using DT.MDM.DAL;
using DT.MDM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DT.MDM.Repositories.Tests
{
    [TestClass]
    public class FieldRepositoryTest
    {
        private MDMContext _context = null;

        private const string _fieldName = "FieldOne";
        private const string _fieldDisplayName = "Field One";

        public FieldRepositoryTest()
        {
            _context = new MDMContext("Data Source=DESKTOP-JKBOHDO;Initial Catalog=MDM;Integrated Security=True;Pooling=False");            
        }

        [TestMethod]
        public async Task CanAddField()
        {
            FieldRepository repo = new FieldRepository(_context);

            Field field = new Field
            {
                Name = _fieldName,
                DisplayName = _fieldDisplayName
            };

            Field createdField = await repo.AddAsync(field);

            Assert.AreEqual(field.Name, createdField.Name);
            Assert.AreEqual(field.DisplayName, createdField.DisplayName);
            Assert.AreNotEqual(0, createdField.Id);
        }

        [TestMethod]
        public async Task CanGetFieldById()
        {
            FieldRepository repo = new FieldRepository(_context);

            Field field = await repo.GetByIdAsync(1);

            Assert.AreEqual(field.Name, _fieldName);
            Assert.AreEqual(field.DisplayName, _fieldDisplayName);
            Assert.AreEqual(field.Id, 1);
        }
    }
}
