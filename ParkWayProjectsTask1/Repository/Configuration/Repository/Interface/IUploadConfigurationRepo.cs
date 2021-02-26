using Microsoft.AspNetCore.Http;
using ParkWayProjectsTask1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkWayProjectsTask1.Repository.Configuration.Repository.Interface
{
    public interface IUploadConfigurationRepo
    {
        Task<GenericResponseModel> uploadConfigurationFileAsync(IFormFile configurationFile);
    }
}
