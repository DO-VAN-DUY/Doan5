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
    public class kiemtraBusiness : IkiemtraBusiness
    {
        private IkiemtraDAL _orderRepository;
        public kiemtraBusiness(IkiemtraDAL productReponsitory)
        {
            _orderRepository = productReponsitory;
        }
        public bool Create(kiemtraModel model)
        {
            return _orderRepository.Create(model);
        }
        public bool Update(kiemtraModel model)
        {
            return _orderRepository.Update(model);
        }
        public List<kiemtraModel> GetDataAll()
        {
            return _orderRepository.GetDataAll();
        }
        public List<kiemtraModel> Getnvvm()
        {
            return _orderRepository.Getnvvm();
        }
        public List<kiemtraModel> Getnvrs()
        {
            return _orderRepository.Getnvrs();
        }
        /* public List<ChitietkiemtraModel> GetDataAllchitiet()
         {
             return _orderRepository.GetDataAllchitiet();
         }*/
        public bool Delete(int id)
        {
            return _orderRepository.Delete(id);
        }
         public kiemtraModel GetkiemtraID(string idnv)
         {
             return _orderRepository.GetkiemtraID(idnv);
         }
        public List<kiemtraModel> Getcheck(string id)
        {
            return _orderRepository.Getcheck(id);
        }
        public List<kiemtraModel> Getkiemtracheck(string idnv)
        {
            return _orderRepository.Getkiemtracheck(idnv);
        }
        public List<kiemtraModel> Search(string tencn)
        {
            return _orderRepository.Search(tencn);
        }
        public List<kiemtraModel> Searchs(int pageIndex, int pageSize, out long total)
        {
            return _orderRepository.Searchs(pageIndex, pageSize, out total);
        }
    }
}


