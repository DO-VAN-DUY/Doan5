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

namespace Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KiemtraController : ControllerBase
    {
        private IkiemtraBusiness _productBusiness;
        private string _path;
        public KiemtraController(IkiemtraBusiness productBusiness, IConfiguration configuration)
        {
            _productBusiness = productBusiness;
            _path = configuration["AppSettings:PATH"];
        }
        [Route("hienthi")]
        [HttpGet]
        public IEnumerable<kiemtraModel> GetDatabAll()
        {
            return _productBusiness.GetDataAll();
        }
        [Route("hienthinvvm")]
        [HttpGet]
        public IEnumerable<kiemtraModel> Getallnvvm()
        {
            return _productBusiness.Getnvvm();
        }
        [Route("hienthinvrs")]
        [HttpGet]
        public IEnumerable<kiemtraModel> Getallnvrs()
        {
            return _productBusiness.Getnvrs();
        }
       [Route("get_by_id")]
        [HttpGet]
        public kiemtraModel GetkiemtraID(string idnv)
        {

            return _productBusiness.GetkiemtraID(idnv);
        }
        [Route("get_check")]
        [HttpGet]
        public IEnumerable<kiemtraModel> Getcheck(string id)
        {

            return _productBusiness.Getcheck(id);
        }
        [Route("Getkiemtra")]
        [HttpGet]
        public IEnumerable<kiemtraModel> Getkiemtracheck(string idnv)
        {

            return _productBusiness.Getkiemtracheck(idnv);
        }

        [Route("themcong")]
        [HttpPost]
        public kiemtraModel Create([FromBody] kiemtraModel model)
        {
            //model.id = Guid.NewGuid().ToString();
            _productBusiness.Create(model);
            return model;
        }

        //[Route("get_khachhang_relationship/{id}")]
        //[HttpGet]
        //public IEnumerable<kiemtraModel> GetByKhachhang(int id)
        //{
        //    return _productBusiness.GetByKhachhang(id);
        //}
        [Route("Suacong")]
        [HttpPost]
        public kiemtraModel UpdateProduct([FromBody] kiemtraModel model)
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
        [Route("Xoacong")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _productBusiness.Delete(id);
            return Ok();
        }
        /* public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
       {
           if (dataFromBase64String.Contains("base64,"))
           {
               dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
           }
           return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
       }
     public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
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
       }*/
        [Route("searchs")]
        [HttpPost]
        public ResponseModel Searchs([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string loc = "";
                if (formData.Keys.Contains("loc") && !string.IsNullOrEmpty(Convert.ToString(formData["loc"]))) { loc = formData["loc"].ToString(); }
                long total = 0;
             
                response.TotalItems = total;
             
                response.Page = page;
                response.PageSize = pageSize;

               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

        [Route("search/{hoten}")]
        [HttpPost]
        public List<kiemtraModel> Search(string hoten)
        {

            return _productBusiness.Search(hoten);
        }
    }
}
