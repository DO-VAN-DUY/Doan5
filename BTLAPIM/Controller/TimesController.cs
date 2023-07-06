using BUS.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Data;

namespace BTLAPIM.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {

        private ItimeBusiness _productBusiness;
        private string _path;
        public TimesController(ItimeBusiness productBusiness, IConfiguration configuration)
        {
            _productBusiness = productBusiness;
            _path = configuration["AppSettings:PATH"];
        }
        [Route("hienthi")]
        [HttpGet]
        public IEnumerable<TimeModel> GetDatabAll()
        {
            return _productBusiness.GetDataAll();
        }
        [Route("Suatime")]
        [HttpPost]
        public TimeModel UpdateProduct([FromBody] TimeModel model)
        {
            _productBusiness.Update(model);
            return model;
        }
        [Route("searchs")]
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
                string Noidung = "";
                string idnv = "";
                if (formData.Keys.Contains("Noidung") && !string.IsNullOrEmpty(Convert.ToString(formData["Noidung"]))) { Noidung = Convert.ToString(formData["Noidung"]); }
                long total = 0;
                var data = _productBusiness.Searchs(page, pageSize, out total, Noidung,idnv);
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
    }
}
