using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyNhanSu.Entity
{
    
    public class Person
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBird { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public DateTime? YearBegin { get; set; }
        public DateTime? OfficialStartYear { get; set; }
        
        public string Levelcode { get; set; } //cap bac
        public string ResponsibleName { get; set; } //chuc vu
        public string AcademicLevelName { get; set; } // trinh do
        public string SchoolName { get; set; } // trinh do
        public DateTime? SchoolYear { get; set; } // năm tot nghiep

        public string InternalSchool { get; set; } // truong noi bo
        public string OtherSchool { get; set; } // truong noi bo
        public string FosteringPLNV { get; set; } // boi duong PLNV
        public string TittleTraning { get; set; } // boi duong chuc danh
        public string TittleTraningPlanning { get; set; } // boi duong quy hoach chuc danh
        public string FosteringQPA { get; set; } // boi duong QP&A

        public string oliticalLevelName { get; set; } // trinh do LLCT
        public string UnitCode { get; set; } // trinh do LLCT
        public string Note { get; set; }
        public byte Type { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
