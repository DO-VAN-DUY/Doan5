using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface IMenuBUS
    {
        bool Create(MenuModel model);
        bool Update(MenuModel model);
        bool Delete(int id);
        List<MenuModel> GetDataAll();
    }
}
