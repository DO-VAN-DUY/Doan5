using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface IphongbanDAL
    {
        bool Create(phongbanModel model);
        bool Update(phongbanModel model);
        bool Delete(int Id);
       // phongbanModel GetDatabyID(int id);
        List<phongbanModel> GetDataAll();
        List<phongbanModel> Search(string tenpb);
        //  List<tonhomModel> GetProductByCategory(int id);
        List<phongbanModel> Searchs(int pageIndex, int pageSize, out long total, string tenpb);
    }
}
