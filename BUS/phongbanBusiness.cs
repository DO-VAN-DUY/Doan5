using DAL.Interfaces;
using Model;
using BUS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class phongbanBusiness : IphongbanBusiness
    {
       private IphongbanDAL _res;
        public phongbanBusiness(IphongbanDAL productCategoryReponsitory)
        {
            _res = productCategoryReponsitory;
        }
        public bool Create(phongbanModel model)
        {
            return _res.Create(model);
        }
       
        public List<phongbanModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<phongbanModel> Search(string tenpb)
        {
            return _res.Search(tenpb);
        }

        public bool Update(phongbanModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(int id)
        {
            return _res.Delete(id);
        }

        public List<phongbanModel> Searchs(int pageIndex, int pageSize, out long total, string tenpb)
        {
            return _res.Searchs(pageIndex, pageSize, out total, tenpb);
        }

    }
}

