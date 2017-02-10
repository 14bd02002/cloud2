using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace mysuperwebSite2.Models
{
    public interface IImageService
{
    Task<UploadedImage> CreateUploadedImage(HttpPostedFileBase file);
}
public class ImageService : IImageService
{
    public async Task<UploadedImage> CreateUploadedImage(HttpPostedFileBase file)
    {
        if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
        {
            byte[] fileBytes = new byte[file.ContentLength];
            await file.InputStream.ReadAsync(fileBytes, 0, Convert.ToInt32(file.ContentLength));
            return new UploadedImage
            {
                ContentType = file.ContentType,
                Data = fileBytes,
                Name = file.FileName,
                // temporarily build a data url to return
                Url = String.Format("data:image/jpeg;base64,{0}", Convert.ToBase64String(fileBytes))
            };
        }
        return null;
    }
}
}