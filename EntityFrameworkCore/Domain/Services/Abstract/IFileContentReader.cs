
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningManagementSystem.Domain.Services.Abstract
{
    public interface IFileContentReader
    {
        string Read(string path);
    }
}
