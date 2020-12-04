using LearningManagementSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningManagementSystem.Db.Configurations
{
    public class StudentSubjectTypeConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder
                .HasKey(s => new { s.StudentId, s.SubjectId });
        }
    }
}
