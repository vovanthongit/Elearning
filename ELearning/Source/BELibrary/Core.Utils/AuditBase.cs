using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ats.Domain
{
    public abstract class AuditBase : IAudit
    {
        public DateTime? AddedTimestamp { get; set; }
        public String AddedUserId { get; set; }
        public DateTime? ChangedTimestamp { get; set; }
        public String ChangedUserId { get; set; }

    }
}
