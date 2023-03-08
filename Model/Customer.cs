using CodingAssessment.Intefaces;
using System;
namespace CodingAssessment.Model
{

    public partial class Customer : Person
    {
        public long CustomerID { get; set; }

        public int? CommunityID { get; set; }

        public string BillingID { get; set; }
                
        public string ModifyBy { get; set; }
        public DateTime ModifyDT { get; set; }

    }
}
