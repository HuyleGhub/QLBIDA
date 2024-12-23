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
using DevExpress.Persistent.Base;
using System.Data.SqlTypes;
namespace QLBIDA.Module.BusinessObjects.QLBIDA
{
    [DefaultClassOptions]

    [DefaultProperty("BanID")]
    public partial class HoaDon : DevExpress.Persistent.BaseImpl.BaseObject
    {

        Ban fBanID;
        [Association(@"HoaDonReferencesBan")]
        public Ban BanID
        {
            get { return fBanID; }
            set { SetPropertyValue<Ban>(nameof(BanID), ref fBanID, value); }
        }
        NhanVien fNhanVienID;
        [Association(@"HoaDonReferencesNhanVien")]
        public NhanVien NhanVienID
        {
            get { return fNhanVienID; }
            set { SetPropertyValue<NhanVien>(nameof(NhanVienID), ref fNhanVienID, value); }
        }
        DateTime fthoiGianBatDau;
        [DevExpress.ExpressApp.Model.ModelDefault("EditMask", "HH:mm"),
         DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "{0:HH:mm}")]
        public DateTime thoiGianBatDau
        {
            get { return fthoiGianBatDau; }
            set
            {
                // Validate thời gian trước khi set
                if (value < SqlDateTime.MinValue.Value)
                {
                    value = DateTime.Now;
                }
                SetPropertyValue<DateTime>(nameof(thoiGianBatDau), ref fthoiGianBatDau, value);
            }
        }
        DateTime fthoiGianKetThuc;
        [DevExpress.ExpressApp.Model.ModelDefault("EditMask", "HH:mm"),
         DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "{0:HH:mm}")]
        public DateTime thoiGianKetThuc
        {
            get { return fthoiGianKetThuc; }
            set
            {
                // Validate thời gian trước khi set
                if (value < SqlDateTime.MinValue.Value)
                {
                    value = DateTime.Now;
                }
                SetPropertyValue<DateTime>(nameof(thoiGianKetThuc), ref fthoiGianKetThuc, value);
            }
        }

        [PersistentAlias("ToStr(Floor(ToDecimal(DateDiffMinute([thoiGianBatDau], [thoiGianKetThuc])) / 60)) + ':' + " +
                     "IIF(DateDiffMinute([thoiGianBatDau], [thoiGianKetThuc]) % 60 < 10, '0', '') + " +
                     "ToStr(DateDiffMinute([thoiGianBatDau], [thoiGianKetThuc]) % 60)")]
        public string tongGioChoi
        {
            get { return Convert.ToString(EvaluateAlias(nameof(tongGioChoi))); }
        }
        DateTime fngayTao;
        [DevExpress.ExpressApp.Model.ModelDefault("EditMask", "dd/MM/yyyy HH:mm"),
         DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "{0:dd/MM/yyyy HH:mm}")]
        public DateTime ngayTao
        {
            get { return fngayTao; }
            set
            {
                // Validate ngày tạo
                if (value < SqlDateTime.MinValue.Value)
                {
                    value = DateTime.Now;
                }
                SetPropertyValue<DateTime>(nameof(ngayTao), ref fngayTao, value);
            }
        }

        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "### ### ### ###")]
        [PersistentAlias("ToDecimal(DateDiffMinute([thoiGianBatDau], [thoiGianKetThuc])) * ([BanID].[giaTheoGio] / 60.0)")]
        public decimal tienGioChoi
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(tienGioChoi))); }
        }

        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "### ### ### ###")]
        public decimal tongTien
        {
            get
            {
                decimal tien = tienGioChoi; // Cộng tiền giờ chơi
                if (HoaDonCTs != null)
                {
                    foreach (HoaDonCT item in HoaDonCTs)
                    {
                        tien += item.thanhTien; // Cộng thành tiền từ từng hóa đơn chi tiết
                    }
                }
                return tien;
            }
        }
        [Association(@"HoaDonCTReferencesHoaDon"), Aggregated]
        public XPCollection<HoaDonCT> HoaDonCTs { get { return GetCollection<HoaDonCT>(nameof(HoaDonCTs)); } }
    }

}