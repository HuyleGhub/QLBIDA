using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace QLBIDA.Module.BusinessObjects.QLBIDA
{

    public partial class DichVu
    {
        public DichVu(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
