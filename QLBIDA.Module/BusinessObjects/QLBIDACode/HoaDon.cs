using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace QLBIDA.Module.BusinessObjects.QLBIDA
{

    public partial class HoaDon
    {
        public HoaDon(Session session) : base(session)
        {
            fthoiGianBatDau = DateTime.Now;
            fthoiGianKetThuc = DateTime.Now;
            fngayTao = DateTime.Now;
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            fthoiGianBatDau = DateTime.Now;
            fthoiGianKetThuc = DateTime.Now;
            fngayTao = DateTime.Now;
        }
    }

}