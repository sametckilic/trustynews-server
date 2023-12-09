using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustyNews.Common.Models;

namespace TrustyNews.Api.Core.Application.Extensions;

public class UploadPhoto
{
    public IConfiguration Configuration { get; }
    public Cloudinary cloudinary;
    public CloudinarySettings cloudinarySettings;

    public UploadPhoto()
    {
        cloudinarySettings = new CloudinarySettings
        {
            CloudName = "dncswzgxh",
            ApiKey = "734174587685431",
            ApiSecret = "-BeEbyVORSdEC4Cl0QV-rhcIkBI"

        };
        Account account = new Account(cloudinarySettings.CloudName,
                                      cloudinarySettings.ApiKey,
                                      cloudinarySettings.ApiSecret);

        cloudinary = new Cloudinary(account);
    }

}
