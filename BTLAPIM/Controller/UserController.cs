using BUS.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersBusiness _userBusiness;
        public UserController(IUsersBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        //[Route("login")]
        //[HttpPost]
        //public IActionResult Login([FromBody] UserModel model)
        //{
        //    var user = _userBusiness.getUser(model.taikhoan, model.matkhau);

        //    if (user == null)
        //        return BadRequest(new { message = "Username or password is incorrect" });
        //    return Ok(new { user_id = user.Id, hoten = user.hoten, taikhoan = user.taikhoan ,token=user.token});


        //}
        [Route("get_all")]
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userBusiness.GetAll();
        }
        [Route("get_bt_id/{id}")]
        [HttpGet]
        public User Get_By_Id(string id)
        {
            return _userBusiness.GetDatabyID(id);
        }
        [Route("create_user")]
        [HttpPost]
        public User CreateProduct([FromBody] User model)
        {
            model.Id = Guid.NewGuid().ToString();
            _userBusiness.Create(model);
            return model;
        }
        [Route("update_user")]
        [HttpPost]
        public User Update([FromBody] User model)
        {
            _userBusiness.Update(model);
            return model;
        }
        [Route("delete_user")]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            _userBusiness.Delete(id);
            return Ok();
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _userBusiness.Authenticate(model.taikhoan, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(new {token = user.token });
        }
    }
}

