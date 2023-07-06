using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public partial interface ITimesDAL
  
    {
        bool Update(TimeModel model);
        List<TimeModel> GetDataAll();
        List<BaocaocongviecModel> Searchs(int pageIndex, int pageSize, out long total, string Noidung,string idnv);
    }
}
