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

    [DefaultProperty("soBan")]
    public partial class Ban : DevExpress.Persistent.BaseImpl.BaseObject
    {
        string fsoBan;
        public string soBan
        {
            get { return fsoBan; }
            set { SetPropertyValue<string>(nameof(soBan), ref fsoBan, value); }
        }
        string ftrangThai;
        public string trangThai
        {
            get { return ftrangThai; }
            set { SetPropertyValue<string>(nameof(trangThai), ref ftrangThai, value); }
        }
        string floaiBan;
        public string loaiBan
        {
            get { return floaiBan; }
            set { SetPropertyValue<string>(nameof(loaiBan), ref floaiBan, value); }
        }
        decimal fgiaTheoGio;
        [DevExpress.ExpressApp.Model.ModelDefault("DisplayFormat", "### ### ### ###"),
DevExpress.ExpressApp.Model.ModelDefault("EditMask", "### ### ### ###")]
        public decimal giaTheoGio
        {
            get { return fgiaTheoGio; }
            set { SetPropertyValue<decimal>(nameof(giaTheoGio), ref fgiaTheoGio, value); }
        }
        [Association(@"HoaDonReferencesBan"), Aggregated]
        public XPCollection<HoaDon> HoaDons { get { return GetCollection<HoaDon>(nameof(HoaDons)); } }
    }

}
