using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public string Id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? sdt { get; set; }
        public string? diachi { get; set; }
        public string? gioitinh { get; set; }
        public string? taikhoan { get; set; }
        public string? Password { get; set; }
        public string? role { get; set; }
        public string? token { get; set; }
        public List<NhanvienModel> @listjson_us { get; set; }
        public List<LylichtrichngangModel> listjson_lltn { get; set; }

    }
}
