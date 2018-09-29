using System;

namespace crystalCLAIMSAPI.Models.Interfaces
{
    public interface IAuditableEntity
    {           
        int? MakerId { get; set; }
        DateTime SubmissionDate { get; set; }
        int? CheckerId { get; set; }
        DateTime? ApprovalDate { get; set; }
        DateTime? RejectionDate { get; set; }
    }
}
