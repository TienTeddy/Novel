using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Entities
{
    public class QrCodeUser
    {
        public int id_qrcode { get; set; }
        public Guid id_user { get; set; }
        public string display { get; set; } // name for QrCode
        public string qrcodeUri { get; set; }
        public DateTime create_date { get; set; }
        public AppUser AppUser { get; set; }
    }
}
