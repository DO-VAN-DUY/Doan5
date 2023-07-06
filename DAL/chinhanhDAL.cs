using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class chinhanhDAL : IChinhanhDAL
    {
        private IDatabaseHelper _dbHelper;
        public chinhanhDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(chinhanh model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_chinhanh",
                //"@id", model.id,
                "@customer_tencn", model.tencn,
                "@customer_diachi", model.diachi,
                "@customer_email", model.email,
                "@customer_sdt", model.sdt
                
                );
                
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
     

        public bool Delete(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_chinhanh",
                "@id", id);
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

        public List<chinhanh> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_chinhanh");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<chinhanh>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<chinhanh> Search( string tencn)
        {
           
            string msgError = "";
           
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_search_chinhanh",
                    "@tencn", tencn
                   );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<chinhanh>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<chinhanh> Searchs(int pageIndex, int pageSize, out long total, string tencn)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "search_chinhanh",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@tencn", tencn);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<chinhanh>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(chinhanh model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "chinhanh_update",
                    "@id", model.Id,
               "@customer_tencn", model.tencn,
                "@customer_diachi", model.diachi,
                "@customer_email", model.email,
                "@customer_sdt", model.sdt
                );

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
      /*  public bool UpdateCN(int id, string TenKH, string Diachi)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "chinhanh_update",
               "@user_id", id,
               "@user_name", TenKH,
                "@user_address", Diachi
                );
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
        public chinhanh getCN(string Email, string Password)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_customer",
                     "@user_email", Email,
                     "@user_password", Password);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<chinhanh>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
    }
}

