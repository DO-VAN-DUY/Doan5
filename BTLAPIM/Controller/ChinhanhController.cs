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
    public class ChinhanhController : ControllerBase
    {
        private IchinhanhBusiness _productBusiness;
        private string _path;
        public ChinhanhController(IchinhanhBusiness productBusiness, IConfiguration configuration)
        {
            _productBusiness = productBusiness;
            _path = configuration["AppSettings:PATH"];
        }
        [Route("hienthi")]
        [HttpGet]
        public IEnumerable<chinhanh> GetDatabAll()
        {
            return _productBusiness.GetDataAll();
        }
        /*[Route("get_by_id/{id}")]
        [HttpGet]
        public chinhanh GetById(int id)
        {

            return _productBusiness.GetDatabyID(id);
        }*/

        [Route("themchinhanh")]
        [HttpPost]
        public chinhanh Create([FromBody] chinhanh model)
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
        [Route("Suachinhanh")]
        [HttpPost]
        public chinhanh UpdateProduct([FromBody] chinhanh model)
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
        [Route("Xoachinhanh")]
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
        [Route("search/{tencn}")]
        [HttpPost]
        public List<chinhanh> Search(string tencn)
        {
           
            return _productBusiness.Search(tencn);
        }
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
                // string Id = "";
                //if (formData.Keys.Contains("item_group_id") && !string.IsNullOrEmpty(Convert.ToString(formData["Id"]))) { Id = Convert.ToString(formData["Id"]); }
                string tencn = "";
                if (formData.Keys.Contains("tencn") && !string.IsNullOrEmpty(Convert.ToString(formData["tencn"]))) { tencn = Convert.ToString(formData["tencn"]); }
                long total = 0;
                var data = _productBusiness.Searchs(page, pageSize, out total, tencn);
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

        //[Route("upload")]
        //[HttpPost, DisableRequestSizeLimit]
        //public async Task<IActionResult> Upload(IFormFile file)
        //{
        //    try
        //    {
        //        if (file.Length > 0)
        //        {
        //            string filePath = $"upload/{file.FileName}";
        //            var fullPath = CreatePathFile(filePath);
        //            using (var fileStream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                await file.CopyToAsync(fileStream);
        //            }
        //            return Ok(new { filePath });
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Không tìm thấy");
        //    }
        //}
        //[NonAction]
        //private string CreatePathFile(string RelativePathFileName)
        //{
        //    try
        //    {
        //        string serverRootPathFolder = _path;
        //        string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
        //        string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
        //        if (!Directory.Exists(fullPathFolder))
        //            Directory.CreateDirectory(fullPathFolder);
        //        return fullPathFile;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
    }
}
