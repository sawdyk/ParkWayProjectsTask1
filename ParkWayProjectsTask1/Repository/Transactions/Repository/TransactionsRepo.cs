using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ParkWayProjectsTask1.Helpers.Utilities;
using ParkWayProjectsTask1.Models;
using ParkWayProjectsTask1.Models.ResponseModels;
using ParkWayProjectsTask1.Repository.Transactions.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ParkWayProjectsTask1.Repository.Transactions.Repository
{
    public class TransactionsRepo : ITransactionsRepo
    {
        private readonly ILogger<TransactionsRepo> _logger;

        public TransactionsRepo(ILogger<TransactionsRepo> logger)
        {
            _logger = logger;
        }
        public async Task<TransactionFeeCalculatorResponseModel> calculateTransactionFeeAsync(long amount)
        {
            try
            {
                //check if the json configuration file exists
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "fees.config.json")))
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "fees.config.json");

                    long feeCharge = 0;

                    //check if the amount is greater than 0
                    if (amount > 0)
                    {
                        using (StreamReader r = new StreamReader(path))
                        {
                            string json = r.ReadToEnd();
                            ChargesModel data = JsonConvert.DeserializeObject<ChargesModel>(json);

                            long countFees = data.fees.Count;

                            for (int i = 0; i < countFees; i++)
                            {
                                if (amount >= data.fees[i].minAmount && amount <= data.fees[i].maxAmount)
                                {
                                    feeCharge = data.fees[i].feeAmount;

                                    return new TransactionFeeCalculatorResponseModel
                                    {
                                        Code = System.Net.HttpStatusCode.OK,
                                        Message = "Transaction Fee Calculation was Successful",
                                        TransferAmount = string.Format("Transfer Amount: N{0}", amount),
                                        Charge = string.Format("Charge: N{0}", feeCharge)
                                    };
                                }
                            }
                        }
                    }

                    return new TransactionFeeCalculatorResponseModel
                    {
                        Code = System.Net.HttpStatusCode.BadRequest,
                        Message = "Amount to be Transferred must be greater than 0"
                    };
                }
              
                return new TransactionFeeCalculatorResponseModel 
                { 
                    Code = System.Net.HttpStatusCode.BadRequest, 
                    Message = "Configuration File Doesn't Exists, Please kindly upload the json Configuration file!" 
                };

            }
            catch (Exception exMessage)
            {
                //Logs Information
                var logInfo = new Logger(_logger);
                logInfo.logException(exMessage);
                return new TransactionFeeCalculatorResponseModel { Code = System.Net.HttpStatusCode.InternalServerError, Message = "An Error Occured" };
            }
        }
    }
}
