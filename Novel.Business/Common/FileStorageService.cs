using Microsoft.AspNetCore.Hosting;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Business.Common
{
    public class FileStorageService : IStorageService
    {
        private readonly string _userContentFolder;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        //private readonly string _qrCodeUserFolder;
        //private const string QRCODE_USER_FOLDER_NAME = "qrcode-user";

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _userContentFolder = Path.Combine(webHostEnvironment.WebRootPath, USER_CONTENT_FOLDER_NAME);
            //_qrCodeUserFolder = Path.Combine(webHostEnvironment.WebRootPath, QRCODE_USER_FOLDER_NAME);
        }

        public string GetFileUrl(string fileName)
        {
            return $"/{USER_CONTENT_FOLDER_NAME}/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        //QrCode
        public async Task<string> SaveQrCodeUser(string qrCodeText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);

            string fileGuid = Guid.NewGuid().ToString();

            qrCodeData.SaveRawData("wwwroot/qrcode-user/" + fileGuid + ".qrr", QRCodeData.Compression.Uncompressed);

            QRCodeData qrCodeData1 = new QRCodeData("wwwroot/qrcode-user/" + fileGuid + ".qrr", QRCodeData.Compression.Uncompressed);

            QRCode qrCode = new QRCode(qrCodeData1);
            Bitmap icon = new Bitmap("wwwroot/qrcode-user/" + "logo_small.png");
            Bitmap qrCodeImage = qrCode.GetGraphic(5, Color.Black, Color.White, icon, 15, 40, true);
            //var result = new
            //{
            //    qrcode = BitmapToBytes(qrCodeImage),
            //    filePath = fileGuid
            //};
            return fileGuid.ToString();
        }
        public async Task RemoveQrCodeAsync(string fileName)
        {
            var filePath = Path.Combine("wwwroot/qrcode-user/" + fileName + ".qrr");
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}
