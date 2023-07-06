using BUS.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class MenuBus : IMenuBUS
    {
        private IMenuDAL _res;
        public MenuBus(IMenuDAL productCategoryReponsitory)
        {
            _res = productCategoryReponsitory;
        }
        public bool Create(MenuModel model)
        {
            return _res.Create(model);
        }
        public List<MenuModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
       
        public bool Update(MenuModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }

    }
}
