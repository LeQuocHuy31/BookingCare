using System;
using System.Collections.Generic;
using System.Text;

namespace flyout.Models
{
    public class ChiTietPhieuKham
    {
        public string ma_phieu { set; get; }
        public string phong_kham { set; get; }
        public string chuyen_khoa { set; get; }
        public string bac_si { get; set; }
        public int stt { set; get; }
        public string ngay { set; get; }
        public string gio { set; get; }
        public string bhyt { set; get; }
        public double gia { set; get; }
        public string ngay_dat_lich { set; get; }
        public int id_chi_tiet_lich_kham { set; get; }
    }
}
