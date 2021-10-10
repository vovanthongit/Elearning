using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ats.Domain
{
    public interface IAudit
    {
        DateTime? AddedTimestamp { get; set; }
        String AddedUserId { get; set; }
        DateTime? ChangedTimestamp { get; set; }
        String ChangedUserId { get; set; }
    }
}
    