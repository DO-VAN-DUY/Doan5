using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface IphongbanBusiness
    {
      
        bool Create(phongbanModel model);
        bool Update(phongbanModel model);
        bool Delete(int Id);
        List<phongbanModel> GetDataAll();
        List<phongbanModel> Search(string tenpb);
        List<phongbanModel> Searchs(int pageIndex, int pageSize, out long total, string tenpb);

    }
}
