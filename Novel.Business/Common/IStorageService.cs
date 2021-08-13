using Novel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Business.Common
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);
        Task SaveFileAsync(Stream mediaBinaryStream, string fileName);
        Task DeleteFileAsync(string fileName);

        Task<string> SaveQrCodeUser (string qrCodeText);
        Task RemoveQrCodeAsync(string fileName);
    }
}
