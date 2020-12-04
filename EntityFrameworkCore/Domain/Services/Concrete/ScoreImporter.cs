using LearningManagementSystem.Domain.Services.Abstract;
using LearningManagementSystem.Domain.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningManagementSystem.Domain.Services.Concrete
{
    public class ScoreImporter : IScoreImporter
    {
        private readonly IFileContentReader _fileContentReader;
        private readonly IFileContentParser _fileContentParser;
        private readonly IRepository _repository;

        public ScoreImporter(IFileContentReader fileContentReader, IFileContentParser fileContentParser, IRepository repository)
        {
            _fileContentReader = fileContentReader;
            _fileContentParser = fileContentParser;
            _repository = repository;
        }

        public ImportResult Import(string path)
        {
            var contents = _fileContentParser.Parse(_fileContentReader.Read(path));

            ImportResult result = new ImportResult();

            foreach (var item in contents)
            {
                var match = _repository.FindByStudentAndSubjectId(item.StudentId, item.SubjectId);

                if (match == null)
                {
                    result.Failed++;
                }
                else
                {
                    match.Score = item.Score;
                    _repository.Save(match);

                    result.Succeeded++;
                }
            }

            return result;
        }
    }
}
