using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using flyout.Models;
namespace flyout.Services
{
    class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool CreateDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "BookingCare.db")))
                {
                    connection.CreateTable<BenhNhan>();
                    connection.CreateTable<NguoiThan>();
                    connection.CreateTable<ThongBao>();
                }
                return true;
            }
            catch (SQLiteException ex)
            {
                return false;
                throw;
            }
        }

        //Thêm hồ sơ bệnh nhân
        public bool ThemHoSo(BenhNhan bn)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "BookingCare.db");
                var connection = new SQLiteConnection(path);
                connection.Insert(bn);
                return true;
            }
            catch (SQLiteException ex)
            {
                return false;
                throw;
            }
        }
        //Cập nhật thông tin bệnh nhân
        public bool UpdateHoSo(BenhNhan bn)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "BookingCare.db");
                var connection = new SQLiteConnection(path);
                connection.Update(bn);
                return true;
            }
            catch (SQLiteException ex)
            {
                return false;
                throw;
            }
        }

        //Lấy thông tin hồ sơ
        public List<BenhNhan> GetBenhNhans()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "BookingCare.db");
                var connection = new SQLiteConnection(path);
                return connection.Table<BenhNhan>().ToList();
            }
            catch (SQLiteException ex)
            {
                return null;
                throw;
            }
        }

        //lấy hồ sơ bênh nhân theo email
        public List<BenhNhan> GetBenhNhanByEmail(string email)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "BookingCare.db");
                var connection = new SQLiteConnection(path);
                return connection.Query<BenhNhan>("select * from BenhNhan where email = '" + email.ToString()+"'");
            }
            catch (SQLiteException ex)
            {
                return null;
                throw;
            }
        }

       






        //Them thong tin nguoi than benh nhan
        public bool AddNguoiThan(NguoiThan nt)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "BookingCare.db");
                var connection = new SQLiteConnection(path);
                connection.Insert(nt);
                return true;
            }
            catch (SQLiteException ex)
            {
                return false;
                throw;
            }
        }
        //Lấy thông tin người thân bệnh nhân 
        public List<NguoiThan> GetNguoiThan(int idBenhNhan)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "BookingCare.db");
                var connection = new SQLiteConnection(path);
                return connection.Query<NguoiThan>("select * from NguoiThan where IDbenhNhan = " + idBenhNhan.ToString());
            }
            catch (SQLiteException ex)
            {
                return null;
                throw;
            }
        }


        //Cập nhật thông tin bệnh nhân
        public bool UpdateThongTinNguoiThan(NguoiThan nt)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "BookingCare.db");
                var connection = new SQLiteConnection(path);
                connection.Update(nt);
                return true;
            }
            catch (SQLiteException ex)
            {
                return false;
                throw;
            }
        }

      
        //Lưu thông báo
        public bool LuuThongBao(ThongBao thongBao)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "BookingCare.db");
                var connection = new SQLiteConnection(path);
                connection.Insert(thongBao);
                return true;
            }
            catch (SQLiteException ex)
            {
                return false;
                throw;
            }
        }
        //Lấy thông báo
        public List<ThongBao> GetThongBao()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "BookingCare.db");
                var connection = new SQLiteConnection(path);
                return connection.Table<ThongBao>().ToList();
            }
            catch (SQLiteException ex)
            {
                return null;
                throw;
            }
        }
        //Cập nhập trạng thái thông báo
        public bool UpdateThongBao(ThongBao thongBao)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, "BookingCare.db");
                var connection = new SQLiteConnection(path);
                connection.Update(thongBao);
                return true;
            }
            catch (SQLiteException ex)
            {
                return false;
                throw;
            }
        }
    }
}
