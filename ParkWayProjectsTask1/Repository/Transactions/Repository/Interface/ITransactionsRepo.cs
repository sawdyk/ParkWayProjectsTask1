using ParkWayProjectsTask1.Models;
using ParkWayProjectsTask1.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkWayProjectsTask1.Repository.Transactions.Repository.Interface
{
    public interface ITransactionsRepo
    {
        Task<TransactionFeeCalculatorResponseModel> calculateTransactionFeeAsync(long amount);
    }
}
