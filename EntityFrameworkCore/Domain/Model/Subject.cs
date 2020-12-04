using System;
using System.Collections.Generic;
using System.Text;

namespace LearningManagementSystem.Domain.Model
{
    public class Subject
    {

        public int SubjectId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StudentSubject> Students { get; set; }
    }
}
