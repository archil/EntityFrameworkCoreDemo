using LearningManagementSystem.Domain.Services.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace LearningManagementSystem.Tests
{
    [TestClass]
    public class FileContentReaderTests
    {
        [TestMethod]
        public void ReadsContents()
        {
            var fileContentReader = new FileContentReader();

            string path = @"C:\Users\User\Source\Repos\EntityFrameworkCoreDemo\LearningManagementSystem.Tests\Grades.csv";
            string contents = File.ReadAllText(path);

            var readResult = fileContentReader.Read(path);

            Assert.AreEqual(contents, readResult);
        }
    }
}
