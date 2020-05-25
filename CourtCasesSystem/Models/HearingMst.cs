using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourtCasesSystem.Models
{
    public class HearingMst
    {
        public int ID { get; set; }
        public int CaseMstID { get; set; }
        public string CurrentDate { get; set; }
        public string NextDate { get; set; }

        public CaseMst CaseMst { get; set; }
    }
}