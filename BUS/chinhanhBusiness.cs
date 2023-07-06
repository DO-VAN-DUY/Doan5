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
    public class chinhanhBusiness : IchinhanhBusiness
    {
        private IChinhanhDAL _orderRepository;
        public chinhanhBusiness(IChinhanhDAL orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public bool Create(chinhanh orderModel)
        {
            return _orderRepository.Create(orderModel);
        }
        public bool Update(chinhanh model)
        {
            return _orderRepository.Update(model);
        }
        public List<chinhanh> GetDataAll()
        {
            return _orderRepository.GetDataAll();
        }
       /* public List<Chitietchinhanh> GetDataAllchitiet()
        {
            return _orderRepository.GetDataAllchitiet();
        }*/
        public bool Delete(int id)
        {
            return _orderRepository.Delete(id);
        }
        public List<chinhanh> Searchs(int pageIndex, int pageSize, out long total, string tencn)
        {
            return _orderRepository.Searchs(pageIndex, pageSize, out total, tencn);
        }

        public List<chinhanh> Search(string tencn)
        {
            return _orderRepository.Search(tencn);
        }
     
     }
       

}
