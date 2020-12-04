using LearningManagementSystem.Domain.Services.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LearningManagementSystem.Domain.Services.Concrete
{
    public class FileContentReader : IFileContentReader
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
