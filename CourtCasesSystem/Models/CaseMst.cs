using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourtCasesSystem.Models
{
    public class CaseMst
    {
        public int ID { get; set; }
        public int JudgeMstID { get; set; }
        public int LawyerMstID { get; set; }
        public int PartyMstID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public JudgeMst JudgeMst { get; set; }
        public LawyerMst LawyerMst { get; set; }
        public PartyMst PartyMst { get; set; }

        public List<HearingMst> HearingMsts { get; set; }
    }
}