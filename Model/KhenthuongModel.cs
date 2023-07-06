using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class KhenthuongModel
    {
        public int Id { get; set; }
        public int idnv { get; set; }
        public int idpb { get; set; }
        public string SoQD { get; set; }
        public string chucvu { get; set; }
        public string khenthuong { get; set; }
        public string HTkhenthuong { get; set; } 
        public string trangthai { get; set; }
        public DateTime ngayky { get; set; }
      
        public DateTime namthidua { get; set; }
    }


}

