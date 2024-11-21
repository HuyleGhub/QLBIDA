﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace QLBIDA.Module.BusinessObjects.QLBIDA
{

    [DefaultProperty("hoTen")]
    public partial class NhanVien : DevExpress.Persistent.BaseImpl.BaseObject
    {
        string fhoTen;
        public string hoTen
        {
            get { return fhoTen; }
            set { SetPropertyValue<string>(nameof(hoTen), ref fhoTen, value); }
        }
        int fsoDT;
        [DevExpress.Persistent.Validation.RuleUniqueValue]
        [DevExpress.ExpressApp.Model.ModelDefault("EditMask", "(\\0###) ### ####")]
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "{0:(\\0###) ### ####}")]
        public int soDT
        {
            get { return fsoDT; }
            set { SetPropertyValue<int>(nameof(soDT), ref fsoDT, value); }
        }
        DateTime fngayVaoLam;
        [DevExpress.ExpressApp.Model.ModelDefault("EditMask", "dd/MM/yyyy HH:mm"),
DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "{0:dd/MM/yyyy HH:mm}")
]
        public DateTime ngayVaoLam
        {
            get { return fngayVaoLam; }
            set { SetPropertyValue<DateTime>(nameof(ngayVaoLam), ref fngayVaoLam, value); }
        }
        decimal fmucLuong;
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "### ### ### ###"),
DevExpress.ExpressApp.Model.ModelDefault("EditMask", "### ### ### ###")]
        public decimal mucLuong
        {
            get { return fmucLuong; }
            set { SetPropertyValue<decimal>(nameof(mucLuong), ref fmucLuong, value); }
        }
        string fchucVu;
        public string chucVu
        {
            get { return fchucVu; }
            set { SetPropertyValue<string>(nameof(chucVu), ref fchucVu, value); }
        }
        [Association(@"HoaDonReferencesNhanVien"), Aggregated]
        public XPCollection<HoaDon> HoaDons { get { return GetCollection<HoaDon>(nameof(HoaDons)); } }
        [Association(@"ChamCongReferencesNhanVien"), Aggregated]
        public XPCollection<ChamCong> ChamCongs { get { return GetCollection<ChamCong>(nameof(ChamCongs)); } }
        [Association(@"BangLuongReferencesNhanVien"), Aggregated]
        public XPCollection<BangLuong> BangLuongs { get { return GetCollection<BangLuong>(nameof(BangLuongs)); } }
        [Association(@"PhieuChiReferencesNhanVien"), Aggregated]
        public XPCollection<PhieuChi> PhieuChis { get { return GetCollection<PhieuChi>(nameof(PhieuChis)); } }
        [Association(@"PhieuNhapReferencesNhanVien"), Aggregated]
        public XPCollection<PhieuNhap> PhieuNhaps { get { return GetCollection<PhieuNhap>(nameof(PhieuNhaps)); } }
    }

}