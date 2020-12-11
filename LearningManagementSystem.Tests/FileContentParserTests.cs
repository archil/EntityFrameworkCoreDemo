using LearningManagementSystem.Domain.Services.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LearningManagementSystem.Tests
{
    [TestClass]
    public class FileContentParserTests
    {
        [TestMethod]
        public void ParseResultsAreValid()
        {
            var fileContentParser = new FileContentParser();

            string contents = @"StudentId,SubjectId,Point
1,2,7";

            var parseResult = fileContentParser.Parse(contents);

            Assert.AreEqual(1, parseResult.Count());
            Assert.AreEqual(1, parseResult.First().StudentId, "Could not read StudentId");
            Assert.AreEqual(2, parseResult.First().SubjectId);
            Assert.AreEqual(7, parseResult.First().Score);
        }
    }
}
