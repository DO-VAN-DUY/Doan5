using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL.Interfaces
{
    
    public partial interface IBacluongDAL
    {
       
        bool Create(BacluongModel model);
        bool Update(BacluongModel model);
        bool Delete(int Id);
       
        List<BacluongModel> GetDataAll();
        //List<chinhanh> Search(string tencn);
        //List<chinhanh> Searchs(int pageIndex, int pageSize, out long total, string tencn);

        /*List<chinhanh> GetByKhachhang(int id);
         *  chinhanh GetDatabyID(int id);
        chinhanh getcn(string tencn, string diachi);
        bool updatecn(int id,string tencn, string diachi);*/
    }
}
