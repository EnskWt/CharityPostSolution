﻿using CharityPost.Core.Domain.Entities.PublicationEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityPost.Core.Helpers
{
    public static class ImagesConverterHelper
    {
        public static List<Image> ConvertImagesToByteArrays(List<IFormFile> files)
        {
            var result = new List<Image>();

            foreach (var file in files)
            {
                using var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);

                var image = new Image
                {
                    Data = memoryStream.ToArray()
                };

                result.Add(image);
            }

            return result;
        }

        public static List<string> ConvertImagesByteArraysToUrls(List<Image> images)
        {
            var result = new List<string>();

            foreach (var image in images)
            {
                result.Add(string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(image.Data)));
            }

            return result;
        }
    }
}
