using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BELibrary.Entity;
using BELibrary.Models;

namespace BELibrary.Core.Entity.Repositories
{
    //this.Configuration.LazyLoadingEnabled = false;
    public interface IRatingRepository : IRepository<Rating>
    {
        RatingDto CalculatorRate(int CourseId);
    }
}