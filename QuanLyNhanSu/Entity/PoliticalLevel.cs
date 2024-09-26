using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyNhanSu.Entity
{
    
    public class PoliticalLevel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public byte Type { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
