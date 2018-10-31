using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Utils;
using Solution.Infrastructure.Database;
using Solution.Model.Entities;
using Solution.Model.Enums;
using Solution.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution.Infrastructure.Tests
{
    [TestClass]
    public class DatabaseUnitOfWorkTest
    {
        public DatabaseUnitOfWorkTest()
        {
            var services = new ServiceCollection();
            services.RegisterServices();
            services.AddDbContextInMemoryDatabase<DatabaseContext>();
            DatabaseUnitOfWork = services.GetService<IDatabaseUnitOfWork>();
            SeedDatabase();
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryAdd()
        {
            var user = CreateUser();
            DatabaseUnitOfWork.UserRepository.Add(user);
            DatabaseUnitOfWork.SaveChanges();
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.Select(user.UserId));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryAddAsynchronous()
        {
            var user = CreateUser();
            DatabaseUnitOfWork.UserRepository.AddAsync(user);
            DatabaseUnitOfWork.SaveChanges();
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.Select(user.UserId));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryAddRange()
        {
            var count = DatabaseUnitOfWork.UserRepository.Count();
            DatabaseUnitOfWork.UserRepository.AddRange(new List<UserEntity> { CreateUser() });
            DatabaseUnitOfWork.SaveChanges();
            Assert.IsTrue(DatabaseUnitOfWork.UserRepository.Count() > count);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryAddRangeAsynchronous()
        {
            var count = DatabaseUnitOfWork.UserRepository.Count();
            DatabaseUnitOfWork.UserRepository.AddRangeAsync(new List<UserEntity> { CreateUser() });
            DatabaseUnitOfWork.SaveChanges();
            Assert.IsTrue(DatabaseUnitOfWork.UserRepository.Count() > count);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryAny()
        {
            Assert.IsTrue(DatabaseUnitOfWork.UserRepository.Any());
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryAnyAsynchronous()
        {
            Assert.IsTrue(DatabaseUnitOfWork.UserRepository.AnyAsync().Result);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryAnyWhere()
        {
            Assert.IsTrue(DatabaseUnitOfWork.UserRepository.Any(w => w.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryAnyWhereAsynchronous()
        {
            Assert.IsTrue(DatabaseUnitOfWork.UserRepository.AnyAsync(w => w.UserId == 1L).Result);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryCount()
        {
            Assert.IsTrue(DatabaseUnitOfWork.UserRepository.Count() > 0);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryCountAsynchronous()
        {
            Assert.IsTrue(DatabaseUnitOfWork.UserRepository.CountAsync().Result > 0);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryCountWhere()
        {
            Assert.IsTrue(DatabaseUnitOfWork.UserRepository.Count(w => w.UserId == 1) == 1L);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryCountWhereAsynchronous()
        {
            Assert.IsTrue(DatabaseUnitOfWork.UserRepository.CountAsync(w => w.UserId == 1L).Result == 1L);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryDelete()
        {
            DatabaseUnitOfWork.UserRepository.Delete(70L);
            DatabaseUnitOfWork.SaveChanges();
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryDeleteAsynchronous()
        {
            DatabaseUnitOfWork.UserRepository.DeleteAsync(80L);
            DatabaseUnitOfWork.SaveChanges();
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryDeleteWhere()
        {
            DatabaseUnitOfWork.UserRepository.Delete(w => w.UserId == 90L);
            DatabaseUnitOfWork.SaveChanges();
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryDeleteWhereAsynchronous()
        {
            DatabaseUnitOfWork.UserRepository.DeleteAsync(w => w.UserId == 100L);
            DatabaseUnitOfWork.SaveChanges();
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefault()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.FirstOrDefault());
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.FirstOrDefaultAsync().Result);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultInclude()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.FirstOrDefault(i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultIncludeAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.FirstOrDefaultAsync(i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultResult()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.FirstOrDefault<SignedInModel>(w => w.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultResultAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.FirstOrDefaultAsync<SignedInModel>(w => w.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultWhere()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.FirstOrDefault(w => w.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultWhereAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.FirstOrDefaultAsync(w => w.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultWhereInclude()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.FirstOrDefault(w => w.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryFirstOrDefaultWhereIncludeAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.FirstOrDefaultAsync(w => w.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryList()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List());
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.ListAsync());
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListInclude()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List(i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListIncludeAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.ListAsync(i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListIncludeResult()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List<UserModel>(i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListIncludeResultAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.ListAsync<UserModel>(i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListPaged()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List(new PagedListParameters()));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListPagedInclude()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List(new PagedListParameters(), i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListPagedIncludeResult()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List<UserModel>(new PagedListParameters(), i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListPagedResult()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List<UserModel>(new PagedListParameters()));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListPagedWhere()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List(new PagedListParameters(), w => w.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListPagedWhereInclude()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List(new PagedListParameters(), w => w.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListPagedWhereIncludeResult()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List<UserModel>(new PagedListParameters(), w => w.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListPagedWhereResult()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List<UserModel>(new PagedListParameters(), w => w.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListResult()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List<UserModel>());
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListResultAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.ListAsync<UserModel>());
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListWhere()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List(w => w.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListWhereAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.ListAsync(w => w.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListWhereInclude()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List(w => w.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListWhereIncludeAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.ListAsync(w => w.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListWhereIncludeResult()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List<UserModel>(w => w.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListWhereIncludeResultAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.ListAsync<UserModel>(w => w.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListWhereResult()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.List<UserModel>(w => w.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryListWhereResultAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.ListAsync<UserModel>(w => w.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryQueryable()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.Queryable.OrderByDescending(o => o.UserId).FirstOrDefault());
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySelect()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.Select(1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySelectAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.SelectAsync(1L).Result);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySelectResult()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.Select<UserModel>(1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySelectResultAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.SelectAsync<UserModel>(1L).Result);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySingleOrDefaultResult()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.SingleOrDefault<SignedInModel>(w => w.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySingleOrDefaultResultAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.SingleOrDefaultAsync<SignedInModel>(w => w.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySingleOrDefaultWhere()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.SingleOrDefault(w => w.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySingleOrDefaultWhereAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.SingleOrDefaultAsync(w => w.UserId == 1L));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySingleOrDefaultWhereInclude()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.SingleOrDefault(w => w.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositorySingleOrDefaultWhereIncludeAsynchronous()
        {
            Assert.IsNotNull(DatabaseUnitOfWork.UserRepository.SingleOrDefaultAsync(w => w.UserId == 1L, i => i.UsersLogs));
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryUpdate()
        {
            var user = DatabaseUnitOfWork.UserRepository.Select(1L);
            user.Name = Guid.NewGuid().ToString();
            DatabaseUnitOfWork.UserRepository.Update(user, 1L);
            DatabaseUnitOfWork.SaveChanges();
            Assert.AreEqual(user.Name, DatabaseUnitOfWork.UserRepository.Select(1L).Name);
        }

        [TestMethod]
        public void DatabaseUnitOfWorkUserRepositoryUpdateAsynchronous()
        {
            var user = DatabaseUnitOfWork.UserRepository.Select(1L);
            user.Name = Guid.NewGuid().ToString();
            DatabaseUnitOfWork.UserRepository.UpdateAsync(user, 1L);
            DatabaseUnitOfWork.SaveChanges();
            Assert.AreEqual(user.Name, DatabaseUnitOfWork.UserRepository.Select(1L).Name);
        }

        private static UserEntity CreateUser()
        {
            var guid = Guid.NewGuid().ToString();

            return new UserEntity
            {
                Name = $"Name {guid}",
                Surname = $"Surname {guid}",
                Email = $"email{guid}@email.com",
                Login = $"login{guid}",
                Password = $"password{guid}",
                Roles = Roles.User | Roles.Admin,
                Status = Status.Active
            };
        }

        private void SeedDatabase()
        {
            for (var i = 1L; i <= 100; i++)
            {
                DatabaseUnitOfWork.UserRepository.Add(CreateUser());
            }

            DatabaseUnitOfWork.SaveChanges();
        }
    }
}
