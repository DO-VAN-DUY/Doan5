using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL.Interfaces
{
    
    public partial interface IkiemtraDAL
    {
       // void checktime()
        
        bool Create(kiemtraModel model);
        bool Update(kiemtraModel model);
        bool Delete(int Id);
        kiemtraModel GetkiemtraID(string idnv);
        List<kiemtraModel> Getcheck(string id);
        List<kiemtraModel> Getkiemtracheck(string idnv);
        List<kiemtraModel> GetDataAll();
        List<kiemtraModel> Getnvvm();
        List<kiemtraModel> Getnvrs();
        List<kiemtraModel> Search(string hoten);
        List<kiemtraModel> Searchs(int pageIndex, int pageSize, out long total);

    }
}
