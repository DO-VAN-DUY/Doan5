using DAL.Helper;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanvienDAL : INhanvienDAL
    {
        private IDatabaseHelper _dbHelper;
        public NhanvienDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(NhanvienModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_nhanvien",
                      "@idtk", model.idtk,
                "@idtn", model.idtn,
                "@hoten", model.hoten,
                "@email", model.email,
                "@sdt", model.sdt,
                 "@diachi", model.diachi,
                "@chucvu", model.chucvu,
                "@gioitinh", model.gioitinh,
                 "@Hinhanh", model.Hinhanh,


                "@luongthoathuan", model.luongthoathuan);

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
        public bool Createbaocao(BaocaocongviecModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_baocao",          
                "@idnv", model.idnv,
                "@thu", model.Thu,
                 "@ngay", model.Ngay

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
        public bool Createtk_ll_nv(User model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "res_create",
                "@id", model.Id,
                "@hoten", model.name,
                "@email", model.email,
                "@sdt", model.sdt,
                 "@diachi", model.diachi,
                "@taikhoan", model.taikhoan,
                "@gioitinh", model.gioitinh,
                "@password", model.Password,
                 "@role", model.role,
                "@listjson_us", model.@listjson_us != null ? MessageConvert.SerializeObject(model.listjson_us) : null,
                "@listjson_lltn", model.listjson_lltn != null ? MessageConvert.SerializeObject(model.listjson_lltn) : null);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_nhanvien",
                "@id", Id);
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

        public List<NhanvienModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_nhanvien");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhanvienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public LylichtrichngangModel get_by_id_LLTNNV(int idnv)
        {
            string msgError = "";
            try
            {
              
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_by_id_LLTNNV",
                   "@idnv", idnv);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<LylichtrichngangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BaocaocongviecModel> GetDatabyIDBC(string idnv)
        {
            string msgError = "";
            try
            {

                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "nhanvien_get_by_id",
                   "@idnv", idnv);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<BaocaocongviecModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public NhanvienModel get_by_id_nhanvien(string idtk)
        { 
            string msgError = "";
            try
            {

                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_by_id_nhanvien",
                   "@idtk",idtk);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhanvienModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public BaocaocongviecModel GetbaocaoID(string idnv)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getbaocaoid",
                    "@idnv", idnv);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<BaocaocongviecModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public NhanvienModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_nhanvien_by_id",
                    "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhanvienModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public List<NhanvienModel> GetByNhanvien(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_nhanvien_relationship",
                    "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhanvienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NhanvienModel> Searchs(int pageIndex, int pageSize, out long total, string hoten)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "search_nhanvien",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@hoten", hoten);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<NhanvienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NhanvienModel> Search( string hoten)
        {
            string msgError = "";
           // total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_search_nhanvien",
                
                    "@hoten", hoten
                   );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
              //  if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<NhanvienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public bool Update(NhanvienModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "nhanvien_update",
                 "@id", model.Id, 
                 "@idtn", model.idtn,
                "@hoten", model.hoten,
                "@email", model.email,
                "@sdt", model.sdt,
                 "@diachi", model.diachi,
                "@chucvu", model.chucvu,
                "@gioitinh", model.gioitinh,
                 "@Hinhanh", model.Hinhanh,
                "@luongthoathuan", model.luongthoathuan);

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
        public bool Updatebaocao(BaocaocongviecModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Baocao_update",
                 "@id", model.Id,
                "@thu", model.Thu,
                "@ngay", model.Ngay,
                "@noidung", model.Noidung,
                 "@ghichu", model.Ghichu
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
        public bool UpdateLLTN(LylichtrichngangModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "LLTN_update",
                 "@id", model.Id,
                  "@idnv", model.idnv,
                 "@hoten", model.hoten,
                "@ngaysinh", model.ngaysinh,
                "@email", model.email,
                "@sdt", model.sdt,
                 "@diachi", model.diachi,
                "@chucvu", model.chucvu,
                "@gioitinh", model.gioitinh,
                 "@Quoctich", model.Quoctich,
                 "@Dantoc", model.Dantoc,
                 "@Tongiao", model.Tongiao,
                 "@Sonha", model.Sonha,
                 "@Masobaohiem", model.Masobaohiem,
                 "@Hotencha", model.Hotencha,
                 "@Namsinh", model.Namsinh,
                 "@Quoctichb", model.Quoctichb,
                 "@Dantocb", model.Dantocb,
                 "@Tongiaob", model.Tongiaob,
                 "@Nghenghiepcha", model.Nghenghiepcha,
                 "@Sdtcha", model.Sdtcha,
                 "@Hokhauthuongtrub", model.Hokhauthuongtrub,
                 "@Hotenme", model.Hotenme,
                 "@Namsinhm", model.Namsinhm,
                 "@Quoctichm", model.Quoctichm,
                 "@Dantocm", model.Dantocm,
                  "@Tongiaom", model.Tongiaom,
                  "@Hokhauthuongtrum", model.Hokhauthuongtrum,
                  "@Slae", model.Slae,
                  "@Hinhanh", model.Hinhanh

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
        public bool CreateCV(CongviecModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_Congviec",
                "@idnv", model.idnv,

                "@idpb", model.idpb,
                 "@idtn", model.idtn,
                "@ngaythuviec", model.ngaythuviec,
                "@ngaychinhthu", model.ngaychinhthuc,
                "@donvi", model.donvi,
                "@chucvu", model.chucvu,
                 "@kiemnhiem", model.kiemnhiem,
                  "@vitri", model.vitri,
                   "@sotruong", model.sotruong,
                    "@danhhieu", model.danhhieu,
                     "@khenthuong", model.khenthuong,
                      "@kyluat", model.kyluat,
                       "@ngaythoatly", model.ngaythoatly,
                        "@ngaybienche", model.ngaybienche);
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

        public bool DeleteCV(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_Congviec",
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

        public List<CongviecModel> GetAllCV()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_Congviec");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<CongviecModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CongviecModel GetDatabyIDCV(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_by_idcongviec",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<CongviecModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool UpdateCV(CongviecModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "update_Congviec",
                "@id", model.Id,
               "@idnv", model.idnv,

                "@idpb", model.idpb,
                 "@idtn", model.idtn,
                "@ngaythuviec", model.ngaythuviec,
                "@ngaychinhthu", model.ngaychinhthuc,
                "@donvi", model.donvi,
                "@chucvu", model.chucvu,
                 "@kiemnhiem", model.kiemnhiem,
                  "@vitri", model.vitri,
                   "@sotruong", model.sotruong,
                    "@danhhieu", model.danhhieu,
                     "@khenthuong", model.khenthuong,
                      "@kyluat", model.kyluat,
                       "@ngaythoatly", model.ngaythoatly,
                        "@ngaybienche", model.ngaybienche);
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
        public bool CreateDH(DanhhieuModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_Danhhieuthidua",
                "@idnv", model.idnv,

                "@idpb", model.idpb,

                "@SoQD", model.SoQD,
                "@chucvu", model.chucvu,
                "@Danhhieu", model.Danhhieu,
                "@trangthai", model.trangthai,
                 "@ngayky", model.ngayky,
                  "@namthidua", model.namthidua
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

        public bool DeleteDH(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_danhhieu",
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

        public List<DanhhieuModel> GetAllDH()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_Danhhieuthidua");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DanhhieuModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DanhhieuModel GetDatabyIDDH(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_by_idDanhhieu",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DanhhieuModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
          public List<UserModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan)
          {
              string msgError = "";
              total = 0;
              try
              {
                  var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "user_search",
                      "@page_index", pageIndex,
                      "@page_size", pageSize,
                      "@hoten", hoten,
                      "@taikhoan", taikhoan);
                  if (!string.IsNullOrEmpty(msgError))
                      throw new Exception(msgError);
                  if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                  return dt.ConvertTo<UserModel>().ToList();
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }
        */
        public bool UpdateDH(DanhhieuModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "update_Danhhieu",
                "@id", model.Id,
              "@idnv", model.idnv,

                "@idpb", model.idpb,

                "@SoQD", model.SoQD,
                "@chucvu", model.chucvu,
                "@Danhhieu", model.Danhhieu,
                "@trangthai", model.trangthai,
                 "@ngayky", model.ngayky,
                  "@namthidua", model.namthidua
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
        public bool CreateHD(HopdongModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_Hopdong",
                "@idnv", model.idnv,

                "@idlhd", model.idlhd,
                 "@idbl", model.idbl,
                "@SoQD", model.SoQD,
                "@TenLHD", model.TenLHD,
                "@Phanloai", model.Phanloai,
                "@trangthai", model.trangthai,
                 "@ngayky", model.ngayky,
                  "@ngayhieuluc", model.ngayhieuluu,
                   "@bacluong", model.bacluong,
                    "@Luuythue", model.Luuythue,
                     "@Masothue", model.Masothue,
                      "@ngayhethan", model.ngayhethan
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

        public bool DeleteHD(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_hopdong",
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

        public List<HopdongModel> GetAllHD()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_Hopdong");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HopdongModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HopdongModel GetDatabyIDHD(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_by_idHopdong",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HopdongModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
          public List<UserModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan)
          {
              string msgError = "";
              total = 0;
              try
              {
                  var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "user_search",
                      "@page_index", pageIndex,
                      "@page_size", pageSize,
                      "@hoten", hoten,
                      "@taikhoan", taikhoan);
                  if (!string.IsNullOrEmpty(msgError))
                      throw new Exception(msgError);
                  if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                  return dt.ConvertTo<UserModel>().ToList();
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }
        */
        public bool UpdateHD(HopdongModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "update_Hopdong",
                "@id", model.Id,
               "@idnv", model.idnv,

                "@idlhd", model.idlhd,
                 "@idbl", model.idbl,
                "@SoQD", model.SoQD,
                "@TenLHD", model.TenLHD,
                "@Phanloai", model.Phanloai,
                "@trangthai", model.trangthai,
                 "@ngayky", model.ngayky,
                  "@ngayhieuluc", model.ngayhieuluu,
                   "@bacluong", model.bacluong,
                    "@Luuythue", model.Luuythue,
                     "@Masothue", model.Masothue,
                      "@ngayhethan", model.ngayhethan
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
        public bool CreateKT(KhenthuongModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_Khenthuong",
                "@idnv", model.idnv,

                "@idpb", model.idpb,
                 "@SoQD", model.SoQD,
                "@chucvu", model.chucvu,
                "@Khenthuong", model.khenthuong,
                "@HTKhenthuong", model.HTkhenthuong,
                "@trangthai", model.trangthai,
                 "@ngayky", model.ngayky,
                  "@namthidua", model.namthidua
                  )
                 ;
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

        public bool DeleteKT(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_khenthuong",
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

        public List<KhenthuongModel> GetAllKT()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_Khenthuong");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhenthuongModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public KhenthuongModel GetDatabyIDKT(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_by_idkhenthuong",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhenthuongModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
          public List<UserModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan)
          {
              string msgError = "";
              total = 0;
              try
              {
                  var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "user_search",
                      "@page_index", pageIndex,
                      "@page_size", pageSize,
                      "@hoten", hoten,
                      "@taikhoan", taikhoan);
                  if (!string.IsNullOrEmpty(msgError))
                      throw new Exception(msgError);
                  if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                  return dt.ConvertTo<UserModel>().ToList();
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }
        */
        public bool UpdateKT(KhenthuongModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "update_Khenthuong",
                "@id", model.Id,
              "@idnv", model.idnv,

                "@idpb", model.idpb,
                 "@SoQD", model.SoQD,
                "@chucvu", model.chucvu,
                "@Khenthuong", model.khenthuong,
                "@HTKhenthuong", model.HTkhenthuong,
                "@trangthai", model.trangthai,
                 "@ngayky", model.ngayky,
                  "@namthidua", model.namthidua
                  )
                 ;
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
        public bool CreatePC(PhucapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_Phucap",
                "@idnv", model.idnv,


                "@SoQD", model.SoQD,
                "@Tenphucap", model.Tenphucap,
                "@heso", model.heso,
                "@sotien", model.sotien,
                 "@ngayky", model.ngayky,
                  "@ngayhieuluc", model.ngayhieuluc

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

        public bool DeletePC(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_phucap",
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

        public List<PhucapModel> GetAllPC()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_phucap");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<PhucapModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PhucapModel GetDatabyIDPC(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_by_id_Phucap",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<PhucapModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
          public List<UserModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan)
          {
              string msgError = "";
              total = 0;
              try
              {
                  var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "user_search",
                      "@page_index", pageIndex,
                      "@page_size", pageSize,
                      "@hoten", hoten,
                      "@taikhoan", taikhoan);
                  if (!string.IsNullOrEmpty(msgError))
                      throw new Exception(msgError);
                  if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                  return dt.ConvertTo<UserModel>().ToList();
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }
        */
        public bool UpdatePC(PhucapModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "update_Phucap",
                "@id", model.Id,
               "@idnv", model.idnv,


                "@SoQD", model.SoQD,
                "@Tenphucap", model.Tenphucap,
                "@heso", model.heso,
                "@sotien", model.sotien,
                 "@ngayky", model.ngayky,
                  "@ngayhieuluc", model.ngayhieuluc);
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
        public bool CreateTD(TrinhdoModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "create_Trinhdo",
             "@idnv", model.idnv,


                "@Hocham", model.Hocham,
                "@Hocvi", model.Hocvi,
                "@Chuyennganh", model.Chuyennganh,
                "@Chuyenmon", model.Chuyenmon,
                 "@Ngoaingu", model.Ngoaingu,
                  "@Tinhoc", model.Tinhoc,
                   "@Vanbangkhac", model.Vanbangkhac,
                    "@ghichu", model.Ghichu
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

        public bool DeleteTD(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "delete_Trinhdo",
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

        public List<TrinhdoModel> GetAllTD()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_all_Trinhdo");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TrinhdoModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TrinhdoModel GetDatabyIDTD(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "get_by_idtrinhdo",
                     "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TrinhdoModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
          public List<UserModel> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan)
          {
              string msgError = "";
              total = 0;
              try
              {
                  var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "user_search",
                      "@page_index", pageIndex,
                      "@page_size", pageSize,
                      "@hoten", hoten,
                      "@taikhoan", taikhoan);
                  if (!string.IsNullOrEmpty(msgError))
                      throw new Exception(msgError);
                  if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                  return dt.ConvertTo<UserModel>().ToList();
              }
              catch (Exception ex)
              {
                  throw ex;
              }
          }
        */
        public bool UpdateTD(TrinhdoModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "update_Trinhdo",
                "@id", model.Id,
               "@idnv", model.idnv,


                "@Hocham", model.Hocham,
                "@Hocvi", model.Hocvi,
                "@Chuyennganh", model.Chuyennganh,
                "@Chuyenmon", model.Chuyenmon,
                 "@Ngoaingu", model.Ngoaingu,
                  "@Tinhoc", model.Tinhoc,
                   "@Vanbangkhac", model.Vanbangkhac,
                    "@ghichu", model.Ghichu
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
    }
}
