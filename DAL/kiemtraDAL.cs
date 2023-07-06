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
    public class kiemtraDAL : IkiemtraDAL
    {
        private IDatabaseHelper _dbHelper;
        public kiemtraDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(kiemtraModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_kiemtra",
                
                "@idnv", model.idnv,
                "@ngay", model.ngay,
                "@giovao", model.giovao,
                "@giora", model.giora,
                "@Lydovaomuon", model.Lydovaomuon,
                "@trangthaivaomuon", model.trangthaivaomuon,
                "@Lydorasom", model.Lydorasom,
                "@trangthairasom", model.trangthairasom,
                "@Hople", model.Hople
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_kiemtra",
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

        public List<kiemtraModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_kiemtra");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<kiemtraModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<kiemtraModel> Getnvvm()  {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_nvvm");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<kiemtraModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<kiemtraModel> Getnvrs()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_nvrs");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<kiemtraModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         public kiemtraModel GetkiemtraID(string idnv)
         {
             string msgError = "";
             try
             {
                 var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getkiemtraid",
                     "@idnv", idnv);
                 if (!string.IsNullOrEmpty(msgError))
                     throw new Exception(msgError);
                 return dt.ConvertTo<kiemtraModel>().FirstOrDefault();
             }
             catch (Exception ex)
             {
                 throw ex;
             }


         }
        public List<kiemtraModel> Getcheck(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getcheck",
                    "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<kiemtraModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        
        public List<kiemtraModel> Getkiemtracheck(string idnv)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getkiemtracheck",
                    "@idnv", idnv);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<kiemtraModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }



        /* public List<kiemtraModel> GetByNhacungcap(int id)
         {
             string msgError = "";
             try
             {
                 var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_ncc_relationship",
                     "@id", id);
                 if (!string.IsNullOrEmpty(msgError))
                     throw new Exception(msgError);
                 return dt.ConvertTo<kiemtraModel>().ToList();
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }*/

        public List<kiemtraModel> Search(string hoten)
        {
            string msgError = "";
          //  total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_search_kiemtra",
                  
                    "@hoten", hoten);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
               // if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<kiemtraModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(kiemtraModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "kiemtra_update",
                 "@id", model.Id,
                "@idnv", model.idnv,
                "@ngay", model.ngay,
                "@giovao", model.giovao,
                "@giora", model.giora,
              
                "@Lydovaomuon", model.Lydovaomuon,
                "@trangthaivaomuon", model.trangthaivaomuon,
                "@Lydorasom", model.Lydorasom,
                "@trangthairasom", model.trangthairasom,
                "@Hople", model.Hople);
                
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
        public List<kiemtraModel> Searchs(int pageIndex, int pageSize, out long total)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "search_kiemtras",
                    "@page_index", pageIndex,
                    "@page_size", pageSize
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<kiemtraModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /* public void checktime()
          {
            DateTim.Now.ToDateShortString();
          }
          /*public bool Checkin(kiemtraModel model)
          {
              string msgError = "";

              if ()
              {
                  try
                  {
                      var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_chinhanh",
                      "@idnv", model.idnv,
                      "@ngay", model.ngay,
                      "@giovao", model.giovao,
                      "@giora", model.giora,
                      "@thang", model.thang,
                      "@Lydovaomuon", model.Lydovaomuon,
                      "@trangthaivaomuon", model.trangthaivaomuon,
                      "@Lydorasom", model.Lydorasom,
                      "@trangthairasom", model.trangthairasom,
                      "@Hople", model.Hople

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
          }*/
    }
}
