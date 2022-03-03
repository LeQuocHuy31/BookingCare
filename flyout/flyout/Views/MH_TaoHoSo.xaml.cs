using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace flyout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MH_TaoHoSo : TabbedPage
    {
        public MH_TaoHoSo()
        {
            InitializeComponent();
            KhoiTao();
        }

        List<chucNang> dscn = new List<chucNang>();
        void KhoiTao()
        {
            dscn.Add(new chucNang { tenChucNang = "Thông tin bệnh nhân", trang =typeof(TaoHoSo) });
            dscn.Add(new chucNang { tenChucNang = "Thông tin người nhà", trang =typeof(Thong_tin_nguoi_nha) });

            for(int i = 0; i < dscn.Count; i++)
            {
                //Page p = (Page)Activator.CreateInstance(dscn[i].trang);
                Page p = (Page)Activator.CreateInstance(dscn[i].trang);
                p.Title = dscn[i].tenChucNang;
                Children.Add(p);
            }
        }
    }
}