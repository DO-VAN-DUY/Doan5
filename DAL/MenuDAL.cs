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
    public class MenuDAL : IMenuDAL
    {
        private IDatabaseHelper _dbHelper;
        public MenuDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        // static int id =0;
        public bool Create(MenuModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_Menu",
               
                "@TenMenu", model.TenMenu,
                 "@Icon", model.Icon,
                   "@link", model.link,
                "@trangthai", model.TrangThai);
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



        public bool Update(MenuModel orderModel)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "menu_update",
                "@id", orderModel.Id,
                "@tenmenu", orderModel.TenMenu,
                  "@Icon", orderModel.Icon,
                    "@link", orderModel.link,
                "@trangthai", orderModel.TrangThai
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
       
        public List<MenuModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_menu");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<MenuModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /* public List<Chitiethoadon> GetDataAllchitiet()
         {
             string msgError = "";
             try
             {
                 var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_ctdonhang");
                 if (!string.IsNullOrEmpty(msgError))
                     throw new Exception(msgError);
                 return dt.ConvertTo<Chitiethoadon>().ToList();
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
        */
        public bool Delete(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Menu_delete",
                "@Id", id);
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
     
    }
}
