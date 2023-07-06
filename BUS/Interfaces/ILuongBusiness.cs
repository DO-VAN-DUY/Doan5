using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BUS.Interfaces
{
    public partial interface ILuongBusiness
    {
        bool Create(LuongModel model);

        //bool Update(LuongModel model);
        //bool Delete(int id);*/
       // KhachhangModel GetDatabyID(int id);
        List<LuongModel> GetDataAll();
        public List<LuongModel> Thongkengay();
        //List<chinhanh> Search(string tencn);
        //List<chinhanh> Searchs(int pageIndex, int pageSize, out long total, string tencn);
        // object Search(int page, int pageSize, out long total, object tencn);
        // List<KhachhangModel> GetByKhachhang(int id);
        // KhachhangModel getKH(string Email, string Password);
        //bool UpdateKH(int id, string TenKH, string Diachi);
    }
}
