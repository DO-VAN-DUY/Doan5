using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUsersssDAL
    {
        User GetUser(string taikhoan, string Password);
        User GetDatabyID(string id);
        bool Create(User model);
     
        bool Update(User model);
        bool Delete(string id);
        List<User> GetAll();
        List<User> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan);
        
    }
}
