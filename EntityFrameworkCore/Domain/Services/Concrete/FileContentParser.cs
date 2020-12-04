using LearningManagementSystem.Domain.Services.Abstract;
using LearningManagementSystem.Domain.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningManagementSystem.Domain.Services.Concrete
{
    public class FileContentParser : IFileContentParser
    {
        public IEnumerable<FileDataItem> Parse(string data)
        {
            var result = data
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(line =>
                {
                    var lineContents = line.Split(",");

                    return new FileDataItem()
                    {
                        StudentId = int.Parse(lineContents[0]),
                        SubjectId = int.Parse(lineContents[1]),
                        Score = int.Parse(lineContents[2])
                    };
                });

            return result;
        }
    }
}
