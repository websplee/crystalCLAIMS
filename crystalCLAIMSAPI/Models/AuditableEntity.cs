using System;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class AuditableEntity : IAuditableEntity
    {
        public int? MakerId { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int? CheckerId { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? RejectionDate { get; set; }
    }
}
