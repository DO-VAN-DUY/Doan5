using Microsoft.Extensions.Configuration;
using BUS.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Controllers
{
    /* [Authorize(Roles = "Quan tri du an")]*/
   
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LuongController : ControllerBase
    {
        private ILuongBusiness _productBusiness;
        private string _path;
        public LuongController(ILuongBusiness productBusiness, IConfiguration configuration)
        {
            _productBusiness = productBusiness;
            _path = configuration["AppSettings:PATH"];
        }
        [Route("hienthi")]
        [HttpGet]
        public IEnumerable<LuongModel> GetDatabAll()
        {
            return _productBusiness.GetDataAll();
        }
        [Route("Thongke")]
        [HttpGet]
        public List<LuongModel> Thongkengay()
        {
            return _productBusiness.Thongkengay();
        }
        /*[Route("get_by_id/{id}")]
        [HttpGet]
        public chinhanh GetById(int id)
        {

            return _productBusiness.GetDatabyID(id);
        }*/

        [Route("themluong")]
        [HttpPost]
        public LuongModel Create([FromBody] LuongModel model)
        {
            //model.id = Guid.NewGuid().ToString();
            _productBusiness.Create(model);
            return model;
        }

        //[Route("get_khachhang_relationship/{id}")]
        //[HttpGet]
        //public IEnumerable<chinhanh> GetByKhachhang(int id)
        //{
        //    return _productBusiness.GetByKhachhang(id);
        //}
       
    }
}
