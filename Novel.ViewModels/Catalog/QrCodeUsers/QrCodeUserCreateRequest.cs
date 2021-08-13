using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.ViewModels.Catalog.QrCodeUsers
{
    public class QrCodeUserCreateRequest
    {
        public Guid id_user { get; set; }
        public string display { get; set; } // link user
        public string qrcodeUri { get; set; }
    }
}
