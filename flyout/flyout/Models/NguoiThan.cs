using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace flyout.Models
{
   public class NguoiThan
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public int IDbenhNhan { get; set; }
        public string Hoten { get; set; }
        public string QuanHe { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }

    }
}
