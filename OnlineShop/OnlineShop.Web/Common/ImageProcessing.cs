using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OnlineShop.Common
{
    static class ImageProcessing
    {
        public static byte[] ImageSaver(HttpPostedFileBase uploadImage)
        {
            using (var binaryReader = new BinaryReader(uploadImage.InputStream))
            {
                return binaryReader.ReadBytes(uploadImage.ContentLength);
            }
        }
    }
}