using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crystalCLAIMSAPI.Models
{
    public class CustomEnums
    {
        public enum ClaimStatus
        {
            PendingWithHCP = 1,
            PendingWithIP = 2, // Submitted to IP and no one has done 
            RejectedByIP = 3, // Until someone at HCP picks up and edits it, it will be in this state
            FullyApproved = 4 // This has been approved by both HCP and IP
        }

        public enum RelationshipType
        {
            Self = 999,
            Spouse = 1,
            Son = 2,
            Daughter = 3,
            Father = 4,
            Mother = 5,
            Niece = 6,
            Brother = 7,
            Sister = 8,
            Nephew = 9,
            Uncle = 10,
            Aunt = 11,
            Grandfather = 12,
            Grandmother = 13,
            Granddaughter = 14,
            Grandson = 15
        }
    }
}
