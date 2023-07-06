using BUS.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : Controller
    {
        private IMenuBUS _productBusiness;
        private string _path;
        public MenuController(IMenuBUS productBusiness, IConfiguration configuration)
        {
            _productBusiness = productBusiness;
            _path = configuration["AppSettings:PATH"];
        }
        [Route("hienthi")]
        [HttpGet]
        public IEnumerable<MenuModel> GetDatabAll()
        {
            return _productBusiness.GetDataAll();
        }
       
        [Route("add_Menu")]
        [HttpPost]
        public MenuModel Create([FromBody] MenuModel model)
        {
            //model.id = Guid.NewGuid().ToString();
            _productBusiness.Create(model);
            return model;
        }

        //[Route("get_khachhang_relationship/{id}")]
        //[HttpGet]
        //public IEnumerable<tonhomModel> GetByKhachhang(int id)
        //{
        //    return _productBusiness.GetByKhachhang(id);
        //}
        [Route("SuaMenu")]
        [HttpPost]
        public MenuModel UpdateProduct([FromBody] MenuModel model)
        {
            _productBusiness.Update(model);
            return model;
        }
        /*[Route("updatekh/id/Tenkh/diachi")]
        [HttpPost]
        public bool UpdateKH(int id,string TenKH,string Diachi)
        {
            return _productBusiness.UpdateKH(id,TenKH,Diachi);
            
        }*/
        [Route("XoaMenu/{id}")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productBusiness.Delete(id);
            return Ok();
        }
    }
}
