using DAL.Interfaces;
using BUS.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TimeBusiness : ItimeBusiness
    {
        private ITimesDAL _orderRepository;
        public TimeBusiness(ITimesDAL orderRepository)
        {
            _orderRepository = orderRepository;
        }
     
        public bool Update(TimeModel model)
        {
            return _orderRepository.Update(model);
        }
        public List<TimeModel> GetDataAll()
        {
            return _orderRepository.GetDataAll();
        }
        public List<BaocaocongviecModel> Searchs(int pageIndex, int pageSize, out long total, string Noidung,string idnv)
        {
            return _orderRepository.Searchs(pageIndex, pageSize, out total, Noidung, idnv);
        }


    }
       

}
