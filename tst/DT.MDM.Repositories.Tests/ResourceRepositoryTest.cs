using DT.MDM.DAL;
using DT.MDM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DT.MDM.Repositories.Tests
{
    [TestClass]
    public class ResourceRepositoryTest
    {
        private MDMContext _context = null;

        private const string _resourceName = "Resource One";
        private const string _resourceDescription = "This is the description of resource one";

        public ResourceRepositoryTest()
        {
            _context = new MDMContext("Data Source=DESKTOP-JKBOHDO;Initial Catalog=MDM;Integrated Security=True;Pooling=False");            
        }

        [TestMethod]
        public async Task CanAddResource()
        {
            ResourceRepository repo = new ResourceRepository(_context);

            Resource resource = new Resource
            {
                Name = _resourceName,
                Description = _resourceDescription
            };

            Resource createdResource = await repo.AddAsync(resource);

            Assert.AreEqual(resource.Name, createdResource.Name);
            Assert.AreEqual(resource.Description, createdResource.Description);
            Assert.AreNotEqual(0, createdResource.Id);
        }

        [TestMethod]
        public async Task CanGetResourceById()
        {
            ResourceRepository repo = new ResourceRepository(_context);

            Resource resource = await repo.GetByIdAsync(1);

            Assert.AreEqual(resource.Name, _resourceName);
            Assert.AreEqual(resource.Description, _resourceDescription);
            Assert.AreEqual(resource.Id, 1);
        }
    }
}
