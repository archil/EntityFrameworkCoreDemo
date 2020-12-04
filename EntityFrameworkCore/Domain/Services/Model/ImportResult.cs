using System;
using System.Collections.Generic;
using System.Text;

namespace LearningManagementSystem.Domain.Services.Model
{
    public class ImportResult
    {
        public int SuccessfullyImported { get; set; }
        public int Failed { get; set; }
    }
}
