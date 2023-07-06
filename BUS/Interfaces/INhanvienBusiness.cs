using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BUS.Interfaces
{
    public partial interface INhanvienBusiness
    {
        bool Create(NhanvienModel model);
        bool Update(NhanvienModel model);
        bool UpdateLLTN(LylichtrichngangModel model);
        bool Delete(int Id);
      
        List<NhanvienModel> GetDataAll();
     
        List<NhanvienModel> Search(string hoten);
        List<NhanvienModel> Searchs(int pageIndex, int pageSize, out long total, string hoten);
        LylichtrichngangModel get_by_id_LLTNNV(int idnv);
        bool Createtk_ll_nv(User model);
        NhanvienModel get_by_id_nhanvien(string idtk);
        List<BaocaocongviecModel> GetDatabyIDBC(string idnv);
        bool Updatebaocao(BaocaocongviecModel model);
        bool Createbaocao(BaocaocongviecModel model);
        BaocaocongviecModel GetbaocaoID(string idnv);
        ///***///
        CongviecModel GetDatabyIDCV(int id);
        bool CreateCV(CongviecModel model);
        bool UpdateCV(CongviecModel model);
        bool DeleteCV(int id);
        List<CongviecModel> GetAllCV();
        /////
        /// DanhhieuModel GetDatabyID(int id);
        DanhhieuModel GetDatabyIDDH(int id);
        bool CreateDH(DanhhieuModel model);
        bool UpdateDH(DanhhieuModel model);
        bool DeleteDH(int id);
        List<DanhhieuModel> GetAllDH();
        /////
        HopdongModel GetDatabyIDHD(int id);
        bool CreateHD(HopdongModel model);
        bool UpdateHD(HopdongModel model);
        bool DeleteHD(int id);
        List<HopdongModel> GetAllHD();
        ////**
        KhenthuongModel GetDatabyIDKT(int id);
        bool CreateKT(KhenthuongModel model);
        bool UpdateKT(KhenthuongModel model);
        bool DeleteKT(int id);
        List<KhenthuongModel> GetAllKT();
        ////
        PhucapModel GetDatabyIDPC(int id);
        bool CreatePC(PhucapModel model);
        bool UpdatePC(PhucapModel model);
        bool DeletePC(int id);
        List<PhucapModel> GetAllPC();
        //***
        TrinhdoModel GetDatabyIDTD(int id);
        bool CreateTD(TrinhdoModel model);
        bool UpdateTD(TrinhdoModel model);
        bool DeleteTD(int id);
        List<TrinhdoModel> GetAllTD();
    }
}
