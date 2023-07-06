using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DAL
{
    public class LuongDAL : ILuongDAL
    {
        private IDatabaseHelper _dbHelper;
        private string connect;
        public LuongDAL(IDatabaseHelper dbHelper, IConfiguration configuration)
        {
            _dbHelper = dbHelper;
            connect = configuration["ConnectionStrings:DefaultConnection"];
        }
        public bool Create(LuongModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_luong",
                //"@id", model.id,
                "@idnv", model.idnv,
                "@ngayhople", model.ngayconghople,
                "@ngaykohople", model.ngaycongkohople,
                "@ngaykhongduoctinh", model.ngaykhongduoctinh,
                "@thang",model.thang,
                "@luongthang",model.luongthang,
                "@luongnhandc",model.luongnhandc,
                "@nguoixuly",model.nguoixuly            
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
     

        //public bool Delete(int id)
        //{
        //    string msgError = "";
        //    try
        //    {
        //        var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_chinhanh",
        //        "@id", id);
        //        if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
        //        {
        //            throw new Exception(Convert.ToString(result) + msgError);
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<LuongModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_luong");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LuongModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //  public List<LuongModel> Thongkengay()
        //  public bool Thongkengay()
        public List<LuongModel> Thongkengay()
        {

            //SqlConnection conn = new SqlConnection("connection string")
            //SqlCommand cmd = new SqlCommand("SELECT nhanvien.hoten,Luong.idnv,Luong.ngayconghople,Luong.ngaycongkohople,Luong.ngaykhongduoctinh FROM Luong,nhanvien WHERE Luong.idnv = nhanvien.idtk ORDER BY nhanvien.hoten ASC", conn);
            // cmd.CommandText = ("Thongkeluong");
            //SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            //adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
            //DataTable dt = new DataTable();
            //adapt.Fill(dt);



            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Thongkeluong");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LuongModel>().ToList();
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

