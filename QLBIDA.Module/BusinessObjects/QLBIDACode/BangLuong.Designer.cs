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
using DevExpress.ExpressApp.Model;
namespace QLBIDA.Module.BusinessObjects.QLBIDA
{

    public partial class BangLuong : DevExpress.Persistent.BaseImpl.BaseObject
    {
        NhanVien fNhanVienID;
        [Association(@"BangLuongReferencesNhanVien")]
        public NhanVien NhanVienID
        {
            get { return fNhanVienID; }
            set
            {
                SetPropertyValue<NhanVien>(nameof(NhanVienID), ref fNhanVienID, value);
                if (!IsLoading && value != null)
                {
                    // Automatically set base salary from NhanVien's salary level
                    luongCoBan = value.mucLuong;
                }
            }
        }

        string fnam;
        public string nam
        {
            get { return fnam; }
            set { SetPropertyValue<string>(nameof(nam), ref fnam, value); }
        }

        string fthang;
        public string thang
        {
            get { return fthang; }
            set { SetPropertyValue<string>(nameof(thang), ref fthang, value); }
        }

        decimal fsoGioLamViec;
        [ModelDefault("DisplayFormat", "### ### ### ###")]
        public decimal soGioLamViec
        {
            get
            {
                // Calculate total working hours from ChamCong records
                if (NhanVienID != null)
                {
                    fsoGioLamViec = CalculateTotalWorkingHours();
                }
                return fsoGioLamViec;
            }
            set { SetPropertyValue<decimal>(nameof(soGioLamViec), ref fsoGioLamViec, value); }
        }

        decimal fluongCoBan;
        [ModelDefault("DisplayFormat", "### ### ### ###"),
        ModelDefault("EditMask", "### ### ### ###")]
        public decimal luongCoBan
        {
            get { return fluongCoBan; }
            set { SetPropertyValue<decimal>(nameof(luongCoBan), ref fluongCoBan, value); }
        }

        decimal fluong;
        [ModelDefault("DisplayFormat", "{0:N0}")]
        [ModelDefault("EditMask", "0")]
        public decimal luong
        {
            get
            {
                // Calculate total salary based on total working hours
                fluong = CalculateTotalSalary();
                return fluong;
            }
            set { SetPropertyValue<decimal>(nameof(luong), ref fluong, value); }
        }

        private decimal CalculateTotalWorkingHours()
        {
            // Filter time attendance records by month and year
            var chamCongRecords = NhanVienID.ChamCongs
                .Where(cc => cc.NgayChamCong.Year.ToString() == nam &&
                             cc.NgayChamCong.Month.ToString() == thang)
                .ToList();

            // Calculate total working hours
            return (decimal)chamCongRecords.Sum(cc => cc.TongGioLamViec.TotalHours);
        }

        private decimal CalculateTotalSalary()
        {
            // Calculate total salary based on total working hours
            if (NhanVienID != null)
            {
                var chamCongRecords = NhanVienID.ChamCongs
                    .Where(cc => cc.NgayChamCong.Year.ToString() == nam &&
                                 cc.NgayChamCong.Month.ToString() == thang)
                    .ToList();

                // Sum the total salary from all time attendance records
                return chamCongRecords.Sum(cc => cc.TongLuong);
            }
            else
            {
                return 0; // Return 0 if NhanVienID is null
            }
        }
    }
}