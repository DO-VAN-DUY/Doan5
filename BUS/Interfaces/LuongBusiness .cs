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
        private ILuongDAL _orderRepository;
        public LuongBusiness(ILuongDAL productReponsitory)
        {
            _orderRepository = productReponsitory;
        }
        public bool Create(LuongModel model)
        {
            return _orderRepository.Create(model);
        }
        public List<LuongModel> GetDataAll()
        {
            return _orderRepository.GetDataAll();
        }
        public List<LuongModel> Thongkengay()
        {
            return _orderRepository.Thongkengay();
        }


    }
}


