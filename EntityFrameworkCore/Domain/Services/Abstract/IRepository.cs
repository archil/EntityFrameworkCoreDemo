using EntityFrameworkCore.Db;
using LearningManagementSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningManagementSystem.Domain.Services.Abstract
{
    public interface IRepository
    {
        StudentSubject FindByStudentAndSubjectId(int studentId, int subjectId);
        void Save(StudentSubject studentSubject);
    }
}
