using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyNhanSu.Entity
{
    
    public class Person
    {
        public int Id { get; set; }
        public string Code { get; set; } //bat buoc
        public string FullName { get; set; } //bat buoc
        public string DateOfBird { get; set; } //bat buoc
        public string Address { get; set; } //bat buoc
        public string Hometown { get; set; } //bat buoc
        public string Sex { get; set; } //bat buoc
        public string ResponsibleName { get; set; }  //chuyen trach
        public string YearBegin { get; set; } //bat buoc //ngay vao 
        public string OfficialStartYear { get; set; } //bat buoc //ngay vao chinh thuc
        public string LevelCode { get; set; } //bat buoc //cap bac
        public string AcademicLevelName { get; set; } //bat buoc // trinh do 
        public string SchoolName { get; set; } // truong
        public string SchoolYear { get; set; } // năm tot nghiep
        public string Department { get; set; } //phong
        public string Position { get; set; } // chuc vu
        public string InternalSchool { get; set; }  //lop trong CAND
        public string OtherSchool { get; set; }//dao tao ngoai nganh
        public string FosteringPLNV { get; set; } // boi duong PLNV
        public string TittleTraning { get; set; } // boi duong chuc danh
        public string TittleTraningPlanning { get; set; } // boi duong quy hoach chuc danh
        public string FosteringQPA { get; set; } // boi duong QP&A
        public string PoliticalLevel { get; set; }//bat buoc // trinh do LLCT
        public string UnitCode { get; set; }//bat buoc // don vi
        public string CommunistPartyBegin { get; set; }//bat buoc // ngay vao dang
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
