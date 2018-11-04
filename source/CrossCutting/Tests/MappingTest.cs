using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.Mapping;
using Solution.Model.Entities;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.CrossCutting.Tests
{
    [TestClass]
    public class MappingTest
    {
        [TestMethod]
        public void MapperClone()
        {
            var source = new UserEntity
            {
                Email = "email@mail.com",
                Login = "login",
                Name = "Name",
                Password = "password",
                UserId = 1
            };

            var result = source.Clone();

            Assert.IsNotNull(result.UserId);
        }

        [TestMethod]
        public void MapperMap()
        {
            var source = new UserEntity { UserId = 1, Roles = Roles.Admin };
            var result = source.Map<SignedInModel>();

            Assert.IsNotNull(result.UserId);
            Assert.IsNotNull(result.Roles);
        }

        [TestMethod]
        public void MapperMerge()
        {
            var source = new UserEntity
            {
                Name = "Name",
                UserId = 1
            };

            var destination = new UserEntity
            {
                Email = "email@mail.com",
                Login = "login",
                Password = "password"
            };

            var result = source.Map(destination);

            Assert.IsNotNull(result.Email);
            Assert.IsNotNull(result.Login);
            Assert.IsNotNull(result.Name);
            Assert.IsNotNull(result.Password);
            Assert.IsNotNull(result.UserId);
        }
    }
}
