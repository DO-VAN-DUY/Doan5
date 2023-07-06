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
    public class TimeDAL : ITimesDAL
    {
        private IDatabaseHelper _dbHelper;
        public TimeDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }  

        public List<TimeModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_time");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TimeModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(TimeModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Time_update",
                    "@id", model.Id,
                 "@giovao", model.Giovao,
                "@giora", model.Giora
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
        public List<BaocaocongviecModel> Searchs(int pageIndex, int pageSize, out long total, string Noidung, string idnv)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "search_baocao",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@noidung", Noidung,
                     "@idnv", idnv);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<BaocaocongviecModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

