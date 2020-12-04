using LearningManagementSystem.Domain.Services.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningManagementSystem.Domain.Services.Abstract
{
    public interface IScoreImporter
    {
        ImportResult Import(string path);
    }
}
