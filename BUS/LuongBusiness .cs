using DAL.Interfaces;
using Model;
using BUS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BUS
{
    public class LuongBusiness : ILuongBusiness
    {
        private ILuongDAL _productBusiness;
        public LuongBusiness (ILuongDAL productReponsitory)
        {
            _productBusiness = productReponsitory;
        }
        public bool Create(LuongModel model)
        {
            return _productBusiness.Create(model);
        }
        public List<LuongModel> GetDataAll()
        {
            return _productBusiness.GetDataAll();
        }
        public List<LuongModel> Thongkengay()
        {
            return _productBusiness.Thongkengay();
        }


    }
}


