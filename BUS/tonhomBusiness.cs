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
    public class tonhomBusiness : ITonhomBusiness
    {
        private ITonhomDAL _res;
        public tonhomBusiness(ITonhomDAL productCategoryReponsitory)
        {
            _res = productCategoryReponsitory;
        }
        public bool Create(tonhomModel model)
        {
            return _res.Create(model);
        }
        public List<tonhomModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public bool CreateLSCT(lichsuchuyento model)
        {
            return _res.CreateLSCT(model);
        }
        public List<lichsuchuyento> GetDataLSCT(int idnv)
        {
            return _res.GetDataLSCT(idnv);
        }
        public List<tonhomModel> Search(string tentn)
        {
            return _res.Search(tentn);
        }

        public bool Update(tonhomModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public List<tonhomModel> Searchs(int pageIndex, int pageSize, out long total, string tentn)
        {
            return _res.Searchs(pageIndex, pageSize, out total, tentn);
        }
    }
}

