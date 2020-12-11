using EntityFrameworkCore.Db;
using LearningManagementSystem.Domain.Model;
using LearningManagementSystem.Domain.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningManagementSystem.Domain.Services.Concrete
{
    public class Repository : IRepository
    {
        readonly LMSDbContext _dbContext;

        public Repository(LMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public StudentSubject FindByStudentAndSubjectId(int studentId, int subjectId)
        {
            var result = _dbContext.Set<StudentSubject>().Find(studentId, subjectId);

            return result;
        }

        public void Save(StudentSubject studentSubject)
        {
            _dbContext.SaveChanges();
        }
    }
}
