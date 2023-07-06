using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL.Interfaces
{
    
    public partial interface ILuongDAL
    {
       
        bool Create(LuongModel model);
       // bool Thongkeluong(LuongModel model,NhanvienModel model1);
        //bool Delete(int Id);
        //List<LuongModel> List<NhanvienModel> Thongkeluong();
        public List<LuongModel> Thongkengay();
       // List<LuongModel> Thongke();
        List<LuongModel> GetDataAll();
        //List<chinhanh> Search(string tencn);
        //List<chinhanh> Searchs(int pageIndex, int pageSize, out long total, string tencn);

        /*List<chinhanh> GetByKhachhang(int id);
         *  chinhanh GetDatabyID(int id);
        chinhanh getcn(string tencn, string diachi);
        bool updatecn(int id,string tencn, string diachi);*/
    }
}
