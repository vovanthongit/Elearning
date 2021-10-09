//using System;
//using System.Linq;
//using BELibrary.Core.Entity.Repositories;
//using BELibrary.Entity;
//using BELibrary.Utils;

//namespace BELibrary.Persistence.Repositories
//{
//    public class CourseSubjectRepository : Repository<CourseSubject>, ICourseSubjectRepository
//    {
//        public CourseSubjectRepository(ELearningDBContext context)
//            : base(context)
//        {
//        }

//        public ELearningDBContext ELearningDBContext
//        {
//            get { return Context as ELearningDBContext; }
//        }
//    }
//}