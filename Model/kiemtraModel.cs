using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class kiemtraModel
    {
        public int Id { get; set; }
       
        public string idnv { get; set; }
        public DateTime ngay { get; set; }
        public DateTime? giovao { get; set; }
        public DateTime? giora { get; set; }
      
        public string? Lydovaomuon { get; set; }
        public int? trangthaivaomuon { get; set; }
        public string? Lydorasom { get; set; }
        public int? trangthairasom { get; set; }
        public int Hople { get; set; }
        
    }
}
