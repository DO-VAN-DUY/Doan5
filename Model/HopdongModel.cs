using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HopdongModel
    {
        public int Id { get; set; }
        public int idnv { get; set; }
        public int idlhd { get; set; }
        public int idbl { get; set; }
        
        public string SoQD { get; set; }
        public string TenLHD { get; set; }
        public string Phanloai { get; set; }
        public string trangthai { get; set; }
        public int bacluong { get; set; }
        public string Luuythue { get; set; }
        public string Masothue { get; set; }
        public DateTime ngayky{ get; set; }
        public DateTime ngayhieuluu { get; set; }
        public DateTime ngayhethan { get; set; }
       
       
    }
}
