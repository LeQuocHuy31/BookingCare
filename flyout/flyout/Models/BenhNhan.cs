using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace flyout.Models
{
    public class BenhNhan
    {
        [PrimaryKey,AutoIncrement]
        public int IdBenhNhan { get; set; }
        public string hoTen { get; set; }
        public string ngaySinh { get; set; }
        public string gioiTinh { get; set; }
        public string danToc { get; set; }
        public string quocGia { get; set; }
        public string email { get; set; }
        public string sdt { get; set; }
        public string CMND { get; set; }
        public string nghe { get; set; }
        public string tinh { get; set; }
    }
}
