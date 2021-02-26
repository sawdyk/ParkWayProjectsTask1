using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ParkWayProjectsTask1.Helpers.Utilities;
using ParkWayProjectsTask1.Models;
using ParkWayProjectsTask1.Repository.Configuration.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ParkWayProjectsTask1.Repository.Configuration.Repository
{
    public class UploadConfigurationRepo : IUploadConfigurationRepo
    {
        private readonly ILogger<UploadConfigurationRepo> _logger;
        public UploadConfigurationRepo(ILogger<UploadConfigurationRepo> logger)
        {
            _logger = logger;
        }
        public async Task<GenericResponseModel> uploadConfigurationFileAsync(IFormFile configurationFile)
        {
            try
            {
                if (configurationFile != null)
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", configurationFile.FileName);

                    //check if the file uploaded is the fees configuration in json format
                    if (configurationFile.FileName == "fees.config.json")
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await configurationFile.CopyToAsync(stream);
                        }

                        return new GenericResponseModel { Code = System.Net.HttpStatusCode.OK, Message = "Configuration File Uploaded Sucessfully!" };
                    }

                    return new GenericResponseModel { Code = System.Net.HttpStatusCode.BadRequest, Message = "Please Kindly Upload the 'fees.config.json' file!" };

                }

                return new GenericResponseModel { Code = System.Net.HttpStatusCode.BadRequest, Message = "Select a file to Upload!" };

            }
            catch (Exception exMessage)
            {
                //Logs Information
                var logInfo = new Logger(_logger);
                logInfo.logException(exMessage);
                return new GenericResponseModel { Code = System.Net.HttpStatusCode.InternalServerError, Message = "An Error Occured" };
            }
        }
    }
}
