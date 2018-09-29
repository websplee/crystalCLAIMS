using System;
using System.Collections.Generic;
using System.Linq;
using crystalCLAIMSAPI.Models.Interfaces;

namespace crystalCLAIMSAPI.Models
{
    public class Member : AuditableEntity, IEntityBase
    {
        public Member()
        {
            Claims = new HashSet<Claim>();
        }

        public int Id { get; set; }
        public int PolicyHolderId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string NationalId { get; set; }
        public string EmployeeNo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? MemberSince { get; set; }
        public CustomEnums.RelationshipType RelationshipType { get; set; }
        public string Gender { get; set; }
        public decimal? AnnualLimit { get; set; }
        public decimal? UtilizedTillDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
        public virtual PolicyHolder PolicyHolder { get; set; }
        // public virtual RelationshipType RelationshipNavigation { get; set; }

    }
}