using LearningManagementSystem.Domain.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningManagementSystem.Domain.Services.Abstract
{
    public interface IFileContentParser
    {
        IEnumerable<FileDataItem> Parse(string data);
    }
}
