using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BELibrary.Models
{
    public class RatingDto
    {
        public double Rate { get; set; }

        public string RateStr { get; set; }

        public string TotalRateStr { get; set; }

        public double Total { get; set; }

        public int Count { get; set; }
    }
}