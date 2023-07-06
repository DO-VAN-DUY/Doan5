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
    public class TonhomController : Controller
    {
        private ITonhomBusiness _productBusiness;
        private string _path;
        public TonhomController(ITonhomBusiness productBusiness, IConfiguration configuration)
        {
            _productBusiness = productBusiness;
            _path = configuration["AppSettings:PATH"];
        }
        [Route("hienthi")]
        [HttpGet]
        public IEnumerable<tonhomModel> GetDatabAll()
        {
            return _productBusiness.GetDataAll();
        }
        /*[Route("get_by_id/{id}")]
        [HttpGet]
        public tonhomModel GetById(int id)
        {

            return _productBusiness.GetDatabyID(id);
        }*/

        [Route("themtonhom")]
        [HttpPost]
        public tonhomModel Create([FromBody] tonhomModel model)
        {
            //model.id = Guid.NewGuid().ToString();
            _productBusiness.Create(model);
            return model;
        }
        [Route("hienthiLSCT")]
        [HttpGet]
        public List<lichsuchuyento> GetDataLSCT(int idnv)
        {

            return _productBusiness.GetDataLSCT(idnv);
        }
      
        [Route("ThemLSCT")]
        [HttpPost]
        public lichsuchuyento CreateLSCT([FromBody] lichsuchuyento model)
        {
            //model.id = Guid.NewGuid().ToString();
            _productBusiness.CreateLSCT(model);
            return model;
        }

        //[Route("get_khachhang_relationship/{id}")]
        //[HttpGet]
        //public IEnumerable<tonhomModel> GetByKhachhang(int id)
        //{
        //    return _productBusiness.GetByKhachhang(id);
        //}
        [Route("Suatonhom")]
        [HttpPost]
        public tonhomModel UpdateProduct([FromBody] tonhomModel model)
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
        [Route("Xoatonhom")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _productBusiness.Delete(id);
            return Ok();
        }

         [Route("search")]
          [HttpPost]
          public ResponseModel Search([FromBody] Dictionary<string, object> formData)
          {
              var response = new ResponseModel();
              try
              {
                  var page = int.Parse(formData["page"].ToString());
                  var pageSize = int.Parse(formData["pageSize"].ToString());
                string loc = "";
                  if (formData.Keys.Contains("loc") && !string.IsNullOrEmpty(Convert.ToString(formData["loc"]))) { loc = formData["loc"].ToString(); }
                  string tentn = "";
                  if (formData.Keys.Contains("tentn") && !string.IsNullOrEmpty(Convert.ToString(formData["tentn"]))) { tentn = Convert.ToString(formData["tentn"]); }
                  long total = 0;
                  var data = _productBusiness.Searchs(page, pageSize, out total, tentn);
                  response.TotalItems = total;
                  response.Data = data;
                  response.Page = page;
                  response.PageSize = pageSize;
              }
              catch (Exception ex)
              {
                  throw new Exception(ex.Message);
              }
              return response;
          }
        [Route("search/{tentn}")]
        [HttpPost]
        public List<tonhomModel> Search(string tentn)
        {

            return _productBusiness.Search(tentn);
        }

    }
}
