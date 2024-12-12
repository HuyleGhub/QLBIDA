using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using QLBIDA.Module.BusinessObjects.QLBIDA;
using System;
using System.Linq;
using DevExpress.Persistent.BaseImpl;

namespace QLBIDA.Module.Controllers
{
    public class ThongKeDoanhThuController : ViewController
    {
        private DateTime fromDate;
        private DateTime toDate;

        public ThongKeDoanhThuController()
        {
            PopupWindowShowAction thongKeAction = new PopupWindowShowAction(
                this,
                "ThongKeDoanhThu",
                DevExpress.Persistent.Base.PredefinedCategory.View
            );
            thongKeAction.Caption = "Thống Kê Doanh Thu";
            thongKeAction.CustomizePopupWindowParams += ThongKeAction_CustomizePopupWindowParams;
            thongKeAction.Execute += ThongKeAction_Execute;
        }

        private void ThongKeAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(ThongKeParameter));
            var parameterObject = objectSpace.CreateObject<ThongKeParameter>();
            e.DialogController.SaveOnAccept = false;
            e.View = Application.CreateDetailView(objectSpace, parameterObject);
        }

        private void ThongKeAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var parameterObject = e.PopupWindowViewCurrentObject as ThongKeParameter;
            if (parameterObject != null)
            {
                fromDate = parameterObject.FromDate;
                toDate = parameterObject.ToDate;

                // Lấy session hiện tại
                var session = ((XPObjectSpace)ObjectSpace).Session;

                // Tính tổng doanh thu trong khoảng thời gian
                var hoaDons = session.Query<HoaDon>()
                .Where(h => h.thoiGianBatDau >= fromDate && h.thoiGianBatDau <= toDate)
                .ToList(); // Tải toàn bộ dữ liệu vào bộ nhớ

                var tongDoanhThu = hoaDons.Sum(h => h.tongTien); // Tính tổng trên dữ liệu đã tải


                // Hiển thị kết quả thông qua MessageOptions
                MessageOptions options = new MessageOptions
                {
                    Duration = 5000, // Thời gian hiển thị (ms)
                    Message = $"Tổng Doanh Thu từ {fromDate:dd/MM/yyyy} đến {toDate:dd/MM/yyyy}: {tongDoanhThu:C}",
                    Type = InformationType.Success
                };
                Application.ShowViewStrategy.ShowMessage(options);
            }
        }
    }

    public class ThongKeParameter : BaseObject
    {
        public ThongKeParameter(Session session) : base(session) { }

        private DateTime fromDate;
        private DateTime toDate;

        public DateTime FromDate
        {
            get => fromDate;
            set => SetPropertyValue(nameof(FromDate), ref fromDate, value);
        }

        public DateTime ToDate
        {
            get => toDate;
            set => SetPropertyValue(nameof(ToDate), ref toDate, value);
        }
    }
}
