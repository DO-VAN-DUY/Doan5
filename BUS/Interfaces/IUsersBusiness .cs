using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface IUsersBusiness
    {
        User Authenticate(string taikhoan,string Password);
      //  UserModel getUser(string email, string Password);
        User GetDatabyID(string id);
        bool Create(User model);
        bool Update(User model);
        bool Delete(string id);
        List<User> GetAll();
    //    object Authenticate(object taikhoan,string Password);
        //List<UserModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan);

    }
}
