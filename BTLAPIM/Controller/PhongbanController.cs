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
    public class PhongbanController : Controller
    {
        private IphongbanBusiness _productBusiness;
        private string _path;
        public PhongbanController(IphongbanBusiness productBusiness, IConfiguration configuration)
        {
            _productBusiness = productBusiness;
            _path = configuration["AppSettings:PATH"];
        }
        [Route("hienthi")]
        [HttpGet]
        public IEnumerable<phongbanModel> GetDatabAll()
        {
            return _productBusiness.GetDataAll();
        }
        /*[Route("get_by_id/{id}")]
        [HttpGet]
        public phongbanModel GetById(int id)
        {

            return _productBusiness.GetDatabyID(id);
        }*/

        [Route("themphongban")]
        [HttpPost]
        public phongbanModel Create([FromBody] phongbanModel model)
        {
            //model.id = Guid.NewGuid().ToString();
            _productBusiness.Create(model);
            return model;
        }

        //[Route("get_khachhang_relationship/{id}")]
        //[HttpGet]
        //public IEnumerable<phongbanModel> GetByKhachhang(int id)
        //{
        //    return _productBusiness.GetByKhachhang(id);
        //}
        [Route("Suaphongban")]
        [HttpPost]
        public phongbanModel UpdateProduct([FromBody] phongbanModel model)
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
        [Route("Xoaphongban")]
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
                string tenpb = "";
                 if (formData.Keys.Contains("tenpb") && !string.IsNullOrEmpty(Convert.ToString(formData["tenpb"]))) { tenpb = Convert.ToString(formData["tenpb"]); }
                 long total = 0;
                 var data = _productBusiness.Searchs(page, pageSize, out total, tenpb);
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
        [Route("search/{tenpb}")]
        [HttpPost]
        public List<phongbanModel> Search(string tenpb)
        {
          
            return _productBusiness.Search(tenpb);
        }

    }
}
