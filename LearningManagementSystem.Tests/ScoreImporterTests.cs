using LearningManagementSystem.Domain.Services.Abstract;
using LearningManagementSystem.Domain.Services.Concrete;
using LearningManagementSystem.Domain.Services.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningManagementSystem.Tests
{
    [TestClass]
    public class ScoreImporterTests
    {
        [TestMethod]
        public void ImportSuccessFailCountIsCorrect()
        {
            string path = "testpath";

            var fileContentReader = new Mock<IFileContentReader>();
            fileContentReader.Setup(f => f.Read(path)).Returns("testContents");

            var fileContentParser = new Mock<IFileContentParser>();
            fileContentParser.Setup(f => f.Parse("testContents"))
                .Returns(new List<FileDataItem>() {
                    new FileDataItem{ StudentId = 1, SubjectId = 2, Score = 3 },
                    new FileDataItem{ StudentId = 1, SubjectId = 3, Score = 17 },
                    new FileDataItem{ StudentId = 1, SubjectId = 4, Score = 3 }
                });

            var correctObject = new Domain.Model.StudentSubject { };

            var repository = new Mock<IRepository>();
            repository.Setup(r => r.FindByStudentAndSubjectId(1, 3)).Returns(correctObject);

            var scorImporter = new ScoreImporter(fileContentReader.Object, fileContentParser.Object, repository.Object);

            var importResult = scorImporter.Import(path);

            Assert.AreEqual(1, importResult.Succeeded);
            Assert.AreEqual(2, importResult.Failed);
            Assert.AreEqual(17, correctObject.Score);
            repository.Verify(c => c.Save(correctObject), Times.Once());
            repository.Verify(c => c.FindByStudentAndSubjectId(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(3));
        }
    }
}
