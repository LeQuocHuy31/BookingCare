using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace flyout.Models
{
    public class ThongBao
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string tieu_de { get; set; }
        public string noi_dung { get; set; }
        public string thoi_gian { get; set; }
        public bool da_xem { get; set; }
    }
}
