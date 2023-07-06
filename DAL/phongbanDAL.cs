using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class phongbanDAL : IphongbanDAL
    {
        private IDatabaseHelper _dbHelper;
        public phongbanDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(phongbanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_phongban",
                
                "@customer_idcn", model.idcn,
                "@customer_tenpb", model.tenpb,
                 "@customer_sdtpb", model.sdtpb,
                  "@customer_trangthai", model.trangthai);
               
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      /*  public phongbanModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "loai_get_by_id",
                     "@loaisp_id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<phongbanModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        public List<phongbanModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_phongban");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<phongbanModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<phongbanModel> Search(string tenpb)
        {
            string msgError = "";
           // total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_search_phongban",
                  
                    "@tenpb", tenpb
                   );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
            //    if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<phongbanModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<phongbanModel> Searchs(int pageIndex, int pageSize, out long total, string tenpb)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "search_phongban",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@tenpb", tenpb);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<phongbanModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(phongbanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "phongban_update",
                "@Id", model.Id,
                "@customer_idcn", model.idcn,
                "@customer_tenpb", model.tenpb,
                 "@customer_sdtpb", model.sdtpb,
                  "@customer_trangthai", model.trangthai);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int Id)
        {
           
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_phongban",
                "@Id", Id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      /*  public List<phongbanModel> GetProductByCategory(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_product_by_category",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<phongbanModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
    }
}
