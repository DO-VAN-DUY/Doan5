using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
     public partial interface ITonhomBusiness
    {
        bool Create(tonhomModel model);
        bool Update(tonhomModel model);
        bool CreateLSCT(lichsuchuyento model);
        List<lichsuchuyento> GetDataLSCT(int idnv);
        bool Delete(int Id);
        List<tonhomModel> GetDataAll();
        List<tonhomModel> Search( string tentn);
        List<tonhomModel> Searchs(int pageIndex, int pageSize, out long total, string tentn);
    }
}
