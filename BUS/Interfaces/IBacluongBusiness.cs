using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces
{
    public partial interface IBacluongBusiness
    {
        //UserModel Authenticate(string taikhoan,string Password);
        //UserModel getUser(string email, string Password);
        //UserModel GetDatabyID(int id);
        bool Create(BacluongModel model);
        bool Update(BacluongModel model);
        bool Delete(int Id);
        List<BacluongModel> GetDataAll();
    //    object Authenticate(object taikhoan,string Password);
        //List<UserModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan);

    }
}
