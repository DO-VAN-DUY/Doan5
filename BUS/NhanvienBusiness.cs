using DAL.Interfaces;
using Model;
using BUS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace BUS
{
    public class NhanvienBusiness : INhanvienBusiness
    {
        private INhanvienDAL _res;
        public NhanvienBusiness(INhanvienDAL productReponsitory)
        {
            _res = productReponsitory;
        }
        public bool Create(NhanvienModel model)
        {
            return _res.Create(model);
        }
        public bool Createbaocao(BaocaocongviecModel model)
        {
            return _res.Createbaocao(model);
        }

        public bool Delete(int Id)
        {
            return _res.Delete(Id);
        }

        public List<NhanvienModel> GetDataAll()
        {
            return _res.GetDataAll();
        }

        /*  public NhanvienModel Search(string hoten)
          {
              return _res.Search(hoten);
          }*/
        public List<NhanvienModel> Search(string hoten)
        {
            return _res.Search(hoten);
        }
       
       

        public bool Update(NhanvienModel model)
        {
            return _res.Update(model);
        }
        public bool Updatebaocao(BaocaocongviecModel model)
        {
            return _res.Updatebaocao(model);
        }
        public bool UpdateLLTN(LylichtrichngangModel model)
        {
            return _res.UpdateLLTN(model);
        }
        public List<NhanvienModel> Searchs(int pageIndex, int pageSize, out long total, string hoten)
        {
            return _res.Searchs(pageIndex, pageSize, out total, hoten);
        }
        public LylichtrichngangModel get_by_id_LLTNNV(int idnv)
        {
            return _res.get_by_id_LLTNNV(idnv);
        }
        public NhanvienModel get_by_id_nhanvien(string idtk)
        {
            return _res.get_by_id_nhanvien(idtk);
        }
        public List<BaocaocongviecModel> GetDatabyIDBC(string idnv)
        {
            return _res.GetDatabyIDBC(idnv);
        }
        public bool Createtk_ll_nv(User model)
        {
            return _res.Createtk_ll_nv(model);
        }
        public BaocaocongviecModel GetbaocaoID(string idnv)
        {
            return _res.GetbaocaoID(idnv);
        }
        public bool CreateCV(CongviecModel model)
        {
            return _res.CreateCV(model);
        }
        public bool UpdateCV(CongviecModel model)
        {
            return _res.UpdateCV(model);
        }
        public List<CongviecModel> GetAllCV()
        {
            return _res.GetAllCV();
        }
       
        public bool DeleteCV(int id)
        {
            return _res.Delete(id);
        }
        public CongviecModel GetDatabyIDCV(int idnv)
        {
            return _res.GetDatabyIDCV(idnv);
        }
        public bool CreateDH(DanhhieuModel model)
        {
            return _res.CreateDH(model);
        }
        public bool UpdateDH(DanhhieuModel model)
        {
            return _res.UpdateDH(model);
        }
        public List<DanhhieuModel> GetAllDH()
        {
            return _res.GetAllDH();
        }

        public bool DeleteDH(int id)
        {
            return _res.DeleteDH(id);
        }
        public DanhhieuModel GetDatabyIDDH(int idnv)
        {
            return _res.GetDatabyIDDH(idnv);
        }
        public bool CreateHD(HopdongModel model)
        {
            return _res.CreateHD(model);
        }
        public bool UpdateHD(HopdongModel model)
        {
            return _res.UpdateHD(model);
        }
        public List<HopdongModel> GetAllHD()
        {
            return _res.GetAllHD();
        }
       
        public bool DeleteHD(int id)
        {
            return _res.DeleteHD(id);
        }
        public HopdongModel GetDatabyIDHD(int idnv)
        {
            return _res.GetDatabyIDHD(idnv);
        }
        public bool CreateKT(KhenthuongModel model)
        {
            return _res.CreateKT(model);
        }
        public bool UpdateKT(KhenthuongModel model)
        {
            return _res.UpdateKT(model);
        }
        public List<KhenthuongModel> GetAllKT()
        {
            return _res.GetAllKT();
        }
      
        public bool DeleteKT(int id)
        {
            return _res.DeleteKT(id);
        }
        public KhenthuongModel GetDatabyIDKT(int idnv)
        {
            return _res.GetDatabyIDKT(idnv);
        }
        public bool CreatePC(PhucapModel model)
        {
            return _res.CreatePC(model);
        }
        public bool UpdatePC(PhucapModel model)
        {
            return _res.UpdatePC(model);
        }
        public List<PhucapModel> GetAllPC()
        {
            return _res.GetAllPC();
        }
       
        public bool DeletePC(int id)
        {
            return _res.DeletePC(id);
        }
        public PhucapModel GetDatabyIDPC(int idnv)
        {
            return _res.GetDatabyIDPC(idnv);
        }
        public bool CreateTD(TrinhdoModel model)
        {
            return _res.CreateTD(model);
        }
        public bool UpdateTD(TrinhdoModel model)
        {
            return _res.UpdateTD(model);
        }
        public List<TrinhdoModel> GetAllTD()
        {
            return _res.GetAllTD();
        }
       
        public bool DeleteTD(int id)
        {
            return _res.DeleteTD(id);
        }
        public TrinhdoModel GetDatabyIDTD(int idnv)
        {
            return _res.GetDatabyIDTD(idnv);
        }
    }
}
