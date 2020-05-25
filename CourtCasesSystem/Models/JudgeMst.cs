using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourtCasesSystem.Models
{
    public class JudgeMst
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public int Age { get; set; }
        public List<CaseMst> CaseMsts { get; set; }
    }
}