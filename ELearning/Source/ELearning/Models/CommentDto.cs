using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELearning.Models
{
    public class CommentDto
    {
        public int Id { get; set; } 
        public string Content { get; set; } 
        public DateTime Time { get; set; } 
        public bool Status { get; set; } 
        public string Username { get; set; } 
        public string FullName { get; set; } 
        public int LectureId { get; set; } 
        public int? ReplyId { get; set; }
        public string AvataUrl { get; set; }

        public  List<CommentDto> Chills { get; set; }
    }
}