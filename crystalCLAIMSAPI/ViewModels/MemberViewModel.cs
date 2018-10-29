using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crystalCLAIMSAPI.Models;

namespace crystalCLAIMSAPI.ViewModels
{
    public class MemberViewModel
    {
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

        public string PolicyHolderName { get; set; }
        public ICollection<ClaimViewModel> Claims { get; set; }
    }
}
