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

    public class UsersBusiness : IUsersBusiness
    {
        private IUsersssDAL _userRepository;
        private string Secret;
        //private readonly AuthenticateModel _context;
        //private readonly IConfiguration _configuration;

        //public UsersBusiness(AuthenticateModel context, IConfiguration configuration)
        //{
        //     _context = context;
        //    _configuration = configuration;

        //}
        public UsersBusiness(IUsersssDAL userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            Secret = configuration["AppSettings:Secret"];

        }
        public bool Create(User model)
        {
            return _userRepository.Create(model);
        }

        public bool Delete(string id)
        {
            return _userRepository.Delete(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetDatabyID(string id)
        {
            return _userRepository.GetDatabyID(id);
        }


         public User Authenticate(string taikhoan, string Password)
          {
              var user= _userRepository.GetUser(taikhoan, Password);
              if (user == null)
                  return null;

              // authentication successful so generate jwt token
              var tokenHandler = new JwtSecurityTokenHandler();
              var key = Encoding.ASCII.GetBytes(Secret);
              var tokenDescriptor = new SecurityTokenDescriptor
              {
                  Subject = new ClaimsIdentity(new Claim[]
                  {
                   
                     new Claim("Id",user.Id.ToString()),

                       new Claim(ClaimTypes.Name, user.name.ToString()),
                       new Claim(ClaimTypes.Email, user.email),
                        new Claim(ClaimTypes.SerialNumber, user.sdt),
                       new Claim(ClaimTypes.StreetAddress, user.diachi),
                        new Claim(ClaimTypes.Role, user.role),



                  }),
                  Expires = DateTime.UtcNow.AddHours(1),
                  SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
              };
              var token = tokenHandler.CreateToken(tokenDescriptor);
              user.token = tokenHandler.WriteToken(token);
              return user;
          }
        
        //public User Authenticate(string taikhoan, string Password)
        //{
        //    var user = _userRepository.GetUser(taikhoan, Password);
        //    if (user == null)
        //        return null;
        //    //    var tokenHandler = new JwtSecurityTokenHandler();

        //    //    var tokenDescriptor = new SecurityTokenDescriptor
        //    //      {
        //    //        Subject = new ClaimsIdentity(new Claim[]
        //    //        {

        //    //                new Claim("Id",user.Id.ToString()),
        //    //                  new Claim("Idnv",user.idnv.ToString()),
        //    //                   new Claim(ClaimTypes.Name, user.name.ToString()),
        //    //                   new Claim(ClaimTypes.Email, user.email),
        //    //                    new Claim(ClaimTypes.SerialNumber, user.sdt),
        //    //                   new Claim(ClaimTypes.StreetAddress, user.diachi),
        //    //                    new Claim(ClaimTypes.Role, user.role),

        //    //         })
        //    //};

        //    //     var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        //    //   // var key = Encoding.ASCII.GetBytes(Secret);
        //    //    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
        //    //    var token = new JwtSecurityToken(
        //    //        _configuration["Jwt:Issuer"],
        //    //        _configuration["Jwt:Audience"],
        //    //        (IEnumerable<Claim>)tokenDescriptor,
        //    //        expires: DateTime.UtcNow.AddHours(2),
        //    //        signingCredentials: signIn);
        //    //    /*return OK(
        //    //      new
        //    //      {
        //    //          User = user.email,
        //    //          token = new JwtSecurityTokenHandler().WriteToken(token)
        //    //      });*/
        //    //   // var tokens = tokenHandler.CreateToken(tokenDescriptor);
        //    //    user.token = new JwtSecurityTokenHandler().WriteToken(token);
        //    //    return user;
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var claims = new List<Claim>
        //    {
        //                  new Claim("Id",user.Id.ToString()),
        //                  new Claim("Idnv",user.idnv.ToString()),
        //                   new Claim(ClaimTypes.Name, user.name.ToString()),
        //                   new Claim(ClaimTypes.Email, user.email),
        //                    new Claim(ClaimTypes.SerialNumber, user.sdt),
        //                   new Claim(ClaimTypes.StreetAddress, user.diachi),
        //                    new Claim(ClaimTypes.Role, user.role),
        //    };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Secret"]));
        //    var signIn = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
        //    var token = new JwtSecurityToken(
        //        _configuration["Jwt:Issuer"],
        //        _configuration["Jwt:Audience"],
        //        claims,
        //        expires: DateTime.UtcNow.AddHours(2),
        //        signingCredentials: signIn);

        //          //token = new JwtSecurityTokenHandler().WriteToken(token)
        //           user.token = tokenHandler.WriteToken(token);
        //            return user;

        //}

    
    public List<User> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan)
        {
            return _userRepository.Search(pageIndex, pageSize, out total, hoten, taikhoan);
        }

        public bool Update(User model)
        {
            return _userRepository.Update(model);
        }
    }
}
