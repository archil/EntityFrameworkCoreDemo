using EntityFrameworkCore.Db;
using LearningManagementSystem.Domain.Model;
using LearningManagementSystem.Domain.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningManagementSystem.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void FindByStudentAndSubjectId()
        {
            var mockDbSet = SetupMockDbSet(new List<StudentSubject>() {
                new StudentSubject
                {
                    StudentId = 1, SubjectId = 2
                }
            });

            var mockContext = new Mock<LMSDbContext>();
            mockContext.Setup(m => m.Set<StudentSubject>().Find(1, 2)).Returns(new StudentSubject { StudentId = 1, SubjectId = 2 });

            var repository = new Repository(mockContext.Object);

            var result = repository.FindByStudentAndSubjectId(1, 2);

            mockContext.Verify(m => m.Set<StudentSubject>());
            Assert.AreEqual(1, result.StudentId);
            Assert.AreEqual(2, result.SubjectId);
        }

        [TestMethod]
        public void Save()
        {
            var mockContext = new Mock<LMSDbContext>();

            var repository = new Repository(mockContext.Object);

            repository.Save(new StudentSubject { });

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }


        private static Mock<DbSet<T>> SetupMockDbSet<T>(List<T> seedData) where T : class
        {
            IQueryable<T> data = seedData.AsQueryable();
            var mockDbSet = new Mock<DbSet<T>>();
            mockDbSet.As<IQueryable<T>>().Setup(t => t.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(t => t.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(t => t.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(t => t.GetEnumerator()).Returns(data.GetEnumerator());
            return mockDbSet;
        }
    }

}
