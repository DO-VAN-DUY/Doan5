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
using System.Collections;

namespace Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NhanvienController : ControllerBase
    {
        private INhanvienBusiness _productBusiness;
        private string _path;
        public NhanvienController(INhanvienBusiness productBusiness, IConfiguration configuration)
        {
            _productBusiness = productBusiness;
            _path = configuration["AppSettings:PATH"];
        }
        [Route("hienthi")]
        [HttpGet]
        public IEnumerable<NhanvienModel> GetDatabAll()
        {
            return _productBusiness.GetDataAll();
        }
        [Route("get_by_idLLTN/{idnv}")]
        [HttpGet]
        public LylichtrichngangModel get_by_id_LLTNNV (int idnv)
        {

            return _productBusiness.get_by_id_LLTNNV(idnv);
        }
        [Route("get_by_id_baocao")]
        [HttpGet]
        public IEnumerable<BaocaocongviecModel> GetDatabyIDBC(string idnv)
        {

            return _productBusiness.GetDatabyIDBC(idnv);
        }
        [Route("get_by_id_nv/{idtk}")]
        [HttpGet]
        public NhanvienModel get_by_id_nhanvien(string idtk)
        {

            return _productBusiness.get_by_id_nhanvien(idtk);
        }
        [Route("getonebaocao")]
        [HttpGet]
        public BaocaocongviecModel GetbaocaoID(string idnv)
        {

            return _productBusiness.GetbaocaoID(idnv);
        }
        [Route("ThemNhanvien")]
        [HttpPost]
        public NhanvienModel Create([FromBody] NhanvienModel model)
        {
            //model.id = Guid.NewGuid().ToString();
            _productBusiness.Create(model);
            return model;
        }
        [Route("Thembaocao")]
        [HttpPost]
        public BaocaocongviecModel Createbaocao([FromBody] BaocaocongviecModel model)
        {
            //model.id = Guid.NewGuid().ToString();
            _productBusiness.Createbaocao(model);
            return model;
        }
        [Route("Test")]
        [HttpPost]
        public User Createtk_ll_nv([FromBody] User model)
        {
            //model.id = Guid.NewGuid().ToString();
            model.Id = Guid.NewGuid().ToString();

            if (model.listjson_us != null)
            {
                foreach (var item in model.listjson_us)
                {
                    item.Id = model.Id;
                    item.Id = Guid.NewGuid().ToString();
                }

            }
            if (model.listjson_lltn != null)
            {
                foreach (var item in model.listjson_lltn)
                {
                    item.Id = model.Id;
                    item.Id = Guid.NewGuid().ToString();
                }

            }
            _productBusiness.Createtk_ll_nv(model);
            return model;
        }

       
        [Route("SuaNhanvien")]
        [HttpPost]
        public NhanvienModel UpdateProduct([FromBody] NhanvienModel model)
        {
            _productBusiness.Update(model);
            return model;
        }
        [Route("Capnhatbaocao")]
        [HttpPost]
        public BaocaocongviecModel Updatebaocao([FromBody] BaocaocongviecModel model)
        {
            _productBusiness.Updatebaocao(model);
            return model;
        }
        [Route("SuaLLTN")]
        [HttpPost]
        public LylichtrichngangModel UpdateLLTN([FromBody] LylichtrichngangModel model)
        {
            _productBusiness.UpdateLLTN(model);
            return model;
        }
       
        [Route("XoaNhanvien")]
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _productBusiness.Delete(Id);
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
                string hoten = "";
                   if (formData.Keys.Contains("hoten") && !string.IsNullOrEmpty(Convert.ToString(formData["hoten"]))) { hoten = Convert.ToString(formData["hoten"]); }
                   long total = 0;
                   var data = _productBusiness.Searchs(page, pageSize, out total, hoten);
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
            // return _productBusiness.Search(hoten);

          }
        [Route("search/{hoten}")]
        [HttpPost]
        public List<NhanvienModel> Search(string hoten)
        {

            return _productBusiness.Search(hoten);
        }
        //      public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        //  {
        //      if (dataFromBase64String.Contains("base64,"))
        //      {
        //          dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
        //      }
        //      return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        //  }
        //public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        //  {
        //      try
        //      {
        //          string result = "";
        //          string serverRootPathFolder = _path;
        //          string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
        //          string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
        //          if (!Directory.Exists(fullPathFolder))
        //              Directory.CreateDirectory(fullPathFolder);
        //          System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
        //          return result;
        //      }
        //      catch (Exception ex)
        //      {
        //          return ex.Message;
        //      }
        //  }
        [Route("upload-multi")]
        [HttpPost]
        public async Task<IActionResult> UploadMulti([FromForm] IFormFile[] Files, [FromForm] string folder)
        {
            try
            {
                List<string> list = new List<string>();
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string filePath = $"/assets/img/{folder}/{file.FileName}";
                        var fullPath = CreatePathFile(filePath);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        list.Add(filePath);

                    }
                }
                return Ok(new { list });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Không thể upload file");
            }
        }
        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] string folder, [FromForm] IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string filePath = $"/assets/img/{folder}/{file.FileName}";
                    var fullPath = CreatePathFile(filePath);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return Ok(new { filePath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Not found!");
            }
        }
        [NonAction]
        private string CreatePathFile(string RelativePathFileName)
        {
            try
            {
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                return fullPathFile;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [Route("hienthi")]
        [HttpGet]
        public IEnumerable<CongviecModel> GetDatabAllCV()
        {
            return _productBusiness.GetAllCV();
        }


        [Route("Createcongviec")]
        [HttpPost]
        public CongviecModel CreateCV([FromBody] CongviecModel model)
        {
            //model.id = Guid.NewGuid().ToString();
            _productBusiness.CreateCV(model);
            return model;
        }


        [Route("Updatecongviec")]
        [HttpPost]
        public CongviecModel UpdateCV([FromBody] CongviecModel model)
        {
            _productBusiness.UpdateCV(model);
            return model;
        }

        [Route("Deletecongviec")]
        [HttpGet]
        public IActionResult Deletecv(int id)
        {
            _productBusiness.DeleteCV(id);
            return Ok();
        }
        [Route("get_by_id_congviec")]
        [HttpGet]
        public CongviecModel get_by_id_congviec(int idnv)
        {

            return _productBusiness.GetDatabyIDCV(idnv);
        }
        [Route("GetDatabAllDanhhieu")]
        [HttpGet]
        public IEnumerable<DanhhieuModel> GetDatabAlldanhhieu()
        {
            return _productBusiness.GetAllDH();
        }


        [Route("CreateDanhhieu")]
        [HttpPost]
        public DanhhieuModel Createdl([FromBody] DanhhieuModel model)
        {
            //model.id = Guid.NewGuid().ToString();
            _productBusiness.CreateDH(model);
            return model;
        }


        [Route("Updatedanhhieu")]
        [HttpPost]
        public DanhhieuModel UpdateDanhhieu([FromBody] DanhhieuModel model)
        {
            _productBusiness.UpdateDH(model);
            return model;
        }

        [Route("DeleteDanhhieu")]
        [HttpGet]
        public IActionResult Deletedl(int id)
        {
            _productBusiness.DeleteDH(id);
            return Ok();
        }
        [Route("get_by_id_danhhieu")]
        [HttpGet]
        public DanhhieuModel get_by_id_danhhieu(int idnv)
        {

            return _productBusiness.GetDatabyIDDH(idnv);
        }
        [Route("GetDatabAllHopdong")]
        [HttpGet]
        public IEnumerable<HopdongModel> GetDatabAllHD()
        {
            return _productBusiness.GetAllHD();
        }
        [Route("CreateHopdong")]
        [HttpPost]
        public HopdongModel CreateHD([FromBody] HopdongModel model)
        {
            //model.id = Guid.NewGuid().ToString();
            _productBusiness.CreateHD(model);
            return model;
        }


        [Route("UpdateHopdong")]
        [HttpPost]
        public HopdongModel UpdateHopdong([FromBody] HopdongModel model)
        {
            _productBusiness.UpdateHD(model);
            return model;
        }

        [Route("DeleteHopdong")]
        [HttpGet]
        public IActionResult DeleteHD(int id)
        {
            _productBusiness.DeleteHD(id);
            return Ok();
        }
        [Route("get_by_id_Hopdong")]
        [HttpGet]
        public HopdongModel get_by_id_Hopdong(int idnv)
        {

            return _productBusiness.GetDatabyIDHD(idnv);
        }
        [Route("GetDatabAllKhenthuong")]
        [HttpGet]
        public IEnumerable<KhenthuongModel> GetDatabAllKT()
        {
            return _productBusiness.GetAllKT();
        }


        [Route("CreateKhenthuong")]
        [HttpPost]
        public KhenthuongModel CreateKT([FromBody] KhenthuongModel model)
        {
            //model.id = Guid.NewGuid().ToString();
            _productBusiness.CreateKT(model);
            return model;
        }


        [Route("Updatekhenthuong")]
        [HttpPost]
        public KhenthuongModel UpdateDanhhieu([FromBody] KhenthuongModel model)
        {
            _productBusiness.UpdateKT(model);
            return model;
        }

        [Route("DeleteKhenthuong")]
        [HttpGet]
        public IActionResult DeleteKT(int id)
        {
            _productBusiness.DeleteKT(id);
            return Ok();
        }
        [Route("get_by_id_Khenthuong")]
        [HttpGet]
        public KhenthuongModel get_by_id_Khenthuong(int idnv)
        {

            return _productBusiness.GetDatabyIDKT(idnv);
        }
        [Route("GetDatabAllPhucap")]
        [HttpGet]
        public IEnumerable<PhucapModel> GetDatabAllPC()
        {
            return _productBusiness.GetAllPC();
        }


        [Route("CreatePhucap")]
        [HttpPost]
        public PhucapModel CreatePC([FromBody] PhucapModel model)
        {
            //model.id = Guid.NewGuid().ToString();
            _productBusiness.CreatePC(model);
            return model;
        }


        [Route("UpdatePhucap")]
        [HttpPost]
        public PhucapModel UpdatePhucap([FromBody] PhucapModel model)
        {
            _productBusiness.UpdatePC(model);
            return model;
        }

        [Route("DeletePhucap")]
        [HttpGet]
        public IActionResult DeletePC(int id)
        {
            _productBusiness.DeletePC(id);
            return Ok();
        }
        [Route("get_by_id_Phucap")]
        [HttpGet]
        public PhucapModel get_by_id_Phucap(int idnv)
        {

            return _productBusiness.GetDatabyIDPC(idnv);
        }
        [Route("GetDatabAllTrinhdo")]
        [HttpGet]
        public IEnumerable<TrinhdoModel> GetDatabAllTD()
        {
            return _productBusiness.GetAllTD();
        }


        [Route("CreateTrinhdo")]
        [HttpPost]
        public TrinhdoModel CreateTD([FromBody] TrinhdoModel model)
        {
            //model.id = Guid.NewGuid().ToString();
            _productBusiness.CreateTD(model);
            return model;
        }


        [Route("UpdateTrinhdo")]
        [HttpPost]
        public TrinhdoModel UpdateTrinhdo([FromBody] TrinhdoModel model)
        {
            _productBusiness.UpdateTD(model);
            return model;
        }

        [Route("DeleteTrinhdo")]
        [HttpGet]
        public IActionResult DeleteTD(int id)
        {
            _productBusiness.DeleteTD(id);
            return Ok();
        }
        [Route("get_by_id_Trinhdo")]
        [HttpGet]
        public TrinhdoModel get_by_id_trinhdo(int idnv)
        {

            return _productBusiness.GetDatabyIDTD(idnv);
        }

    }
}
