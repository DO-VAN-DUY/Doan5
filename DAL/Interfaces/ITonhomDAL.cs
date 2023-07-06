using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITonhomDAL
    {
        bool Create(tonhomModel model);
        bool CreateLSCT(lichsuchuyento model);

        bool Update(tonhomModel model);
        bool Delete(int id);
        List<tonhomModel> GetDataAll();
      
        List<lichsuchuyento> GetDataLSCT(int idnv);
        // tonhomModel Timkiem(string id);

        List<tonhomModel> Search(string tentn);
        List<tonhomModel> Searchs(int pageIndex, int pageSize, out long total, string tentn);
       // List<Chitiethoadon> GetDataAllchitiet();

    }
}
