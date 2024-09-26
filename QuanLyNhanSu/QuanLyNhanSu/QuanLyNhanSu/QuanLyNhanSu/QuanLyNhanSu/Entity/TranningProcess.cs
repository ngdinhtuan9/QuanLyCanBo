using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyNhanSu.Entity
{
    
    public class TranningProcess
    {
        public int Id { get; set; }
        public string PersonCode { get; set; }
        public string SchoolName { get; set; }
        public string Major { get; set; }
        public string Level { get; set; }
        public string DecisionNumber { get; set; }
        public string BeginYear { get; set; }
        public string EndYear { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
