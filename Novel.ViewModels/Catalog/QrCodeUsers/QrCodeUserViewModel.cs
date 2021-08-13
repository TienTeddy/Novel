using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.ViewModels.Catalog.QrCodeUsers
{
    public class QrCodeUserViewModel
    {
        public int id_qrcode { get; set; }
        public Guid id_user { get; set; }
        public string display { get; set; } // link user
        public string qrcodeUri { get; set; }
        public DateTime create_date { get; set; }
    }
}
