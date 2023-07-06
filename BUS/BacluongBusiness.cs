using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BUS.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace BUS
{

    public class BacluongBusiness : IBacluongBusiness
    {
        private IBacluongDAL _userRepository;
        private string Secret;
        public BacluongBusiness(IBacluongDAL userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            Secret = configuration["AppSettings:Secret"];

        }
        public bool Create(BacluongModel model)
        {
            return _userRepository.Create(model);
        }

        public bool Delete(int Id)
        {
            return _userRepository.Delete(Id);
        }

        public List<BacluongModel> GetDataAll()
        {
            return _userRepository.GetDataAll();
        }
        public bool Update(BacluongModel model)
        {
            return _userRepository.Update(model);
        }
    }
}

        //public User GetDatabyID(int id)
        //{
        //    return _userRepository.GetDatabyID(id);
        //}


//public User Authenticate(string taikhoan, string Password)
//{
//    var user= _userRepository.GetUser(taikhoan, Password);
//    if (user == null)
//        return null;

//    // authentication successful so generate jwt token
//    var tokenHandler = new JwtSecurityTokenHandler();
//    var key = Encoding.ASCII.GetBytes(Secret);
//    var tokenDescriptor = new SecurityTokenDescriptor
//    {
//        Subject = new ClaimsIdentity(new Claim[]
//        {
//             new Claim(ClaimTypes.Name, user.Taikhoan.ToString()),
//            new Claim(ClaimTypes.StreetAddress, user.diachi)
//        }),
//        Expires = DateTime.UtcNow.AddDays(7),
//        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//    };
//    var token = tokenHandler.CreateToken(tokenDescriptor);
//    user.token = tokenHandler.WriteToken(token);
//    return user;
//}

/*   public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
   {
       if (dataFromBase64String.Contains("base64,"))
       {
           dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
       }
       return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
   }

  /* public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
   {
       try
       {
           string result = "";
           string serverRootPathFolder = _path;
           string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
           string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
           if (!Directory.Exists(fullPathFolder))
               Directory.CreateDirectory(fullPathFolder);
           System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
           return result;
       }
       catch (Exception ex)
       {
           return ex.Message;
       }
   }*
   //public UserModel getUser(string taikhoan, string matkhau)
   //{
   //var user = _userRepository.GetUser(taikhoan, matkhau);
   //// return null if user not found
   //if (user == null)
   //    return null;

   //// authentication successful so generate jwt token
   ////var tokenHandler = new JwtSecurityTokenHandler();
   //var key = Encoding.ASCII.GetBytes(Secret);
   //var tokenDescriptor = new SecurityTokenDescriptor
   //{
   //    Subject = new ClaimsIdentity(new Claim[]
   //    {
   //        new Claim(ClaimTypes.Name, user.hoten.ToString()),
   //        new Claim(ClaimTypes.StreetAddress, user.diachi)
   //    }),
   //    Expires = DateTime.UtcNow.AddDays(7),
   //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
   //};
   //var token = tokenHandler.CreateToken(tokenDescriptor);
   //user.token = tokenHandler.WriteToken(token);

   // return user;


   //}

   public List<UserModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan)
   {
       return _userRepository.Search(pageIndex, pageSize, out total, hoten, taikhoan);
   }

   public bool Update(UserModel model)
   {
       return _userRepository.Update(model);
   }
}
}*/
