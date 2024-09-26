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
        public string Hometown { get; set; } //bat buoc
        public string Address { get; set; } //bat buoc
        public string Sex { get; set; } //bat buoc
        public string ResponsibleName { get; set; }  //chuyen trach
        public string YearBegin { get; set; } //bat buoc //ngay vao 
        public string OfficialStartYear { get; set; } //bat buoc //ngay vao chinh thuc
        public string CommunistPartyBegin { get; set; }//bat buoc // ngay vao dang
        public string LevelCode { get; set; } //bat buoc //cap bac
        public string Tittle { get; set; } //chuc danh
        public string Position { get; set; } // chuc vu

       

        public string InternalAcademicLevelName { get; set; }
        public string InternalMajor { get; set; }// chuyen nganh trong CAND
        public string InternalSchool { get; set; }  //lop trong CAND
        public string InternalSchoolYear { get; set; }
        public string InternalTraningType { get; set; }

        public string AcademicLevelName { get; set; } //bat buoc // trinh do 
        public string Major { get; set; }// chuyen nganh ngoài CAND
        public string SchoolName { get; set; } // truong
        public string SchoolYear { get; set; } // năm tot nghiep
        public string TraningType { get; set; }

        public string CurInternalSchool { get; set; }  //dang dao tao cac lop trong CAND
        public string CurInternalMajor { get; set; }// chuyen nganh đang học trong CAND
        public string CurInternalAcademicLevelName { get; set; }
        public string CurInternalSchoolYear { get; set; }
        public string CurInternalTraningType { get; set; }

        public string FosteringPLNV { get; set; } // boi duong PLNV
        public string TittleTraning { get; set; } // boi duong chuc danh
        public string TittleTraningPlanning { get; set; } // boi duong quy hoach chuc danh
        public string FosteringQPA { get; set; } // boi duong QP&A
        public string PoliticalLevel { get; set; }//bat buoc // trinh do LLCT
        public string PoliticalLevelForm { get; set; } //hình thức dtao LLCT
        public string Classify { get; set; }//Phân loại cán bộ
        public string Competition { get; set; }//Phân loại thi đua
        
        public string UnitCode { get; set; }//bat buoc // don vi
        public string Department { get; set; } //phong
        
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
