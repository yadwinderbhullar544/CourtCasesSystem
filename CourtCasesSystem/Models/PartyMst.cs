using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourtCasesSystem.Models
{
    public class PartyMst
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public List<CaseMst> CaseMsts { get; set; }
    }
}