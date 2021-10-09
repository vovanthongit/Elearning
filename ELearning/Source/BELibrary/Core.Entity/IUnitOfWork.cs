using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BELibrary.Core.Entity.Repositories;

namespace BELibrary.Core.Entity
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Account { get; }
        ICommentRepository Comments { get; }
        ICourseRepository Courses { get; }
        //ICourseSubjectRepository CourseSubject { get; }
        IDocumentRepository Documents { get; }
        ILectureRepository Lectures { get; }
        IRatingRepository Rating { get; }
        IRoleRepository Role { get; }
        IStudentSubjectRepository StudentSubjects { get; }
        IStudentTestRepository StudentTests { get; }
        ISubjectRepository Subjects { get; }
        ITeacherSubjectRepository TeacherSubjects { get; }

        int Complete();
    }
}