using LearningManagementSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningManagementSystem.Domain.Services.Abstract
{
    interface IRepository
    {
        StudentSubject FindByStudentAndSubjectId(int studentId, int subjectId);
        void Save(StudentSubject studentSubject);
    }
}
