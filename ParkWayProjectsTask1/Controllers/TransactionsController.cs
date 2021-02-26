using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkWayProjectsTask1.Repository.Configuration.Repository.Interface;
using ParkWayProjectsTask1.Repository.Transactions.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWayProjectsTask1.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionsRepo _transactionsRepo;
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(ITransactionsRepo transactionsRepo, ILogger<TransactionsController> logger)
        {
            _transactionsRepo = transactionsRepo;
            _logger = logger;
        }

        // GET: TransactionsController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CalculateTransactionFee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalculateTransactionFee(long amount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _transactionsRepo.calculateTransactionFeeAsync(amount);

            ViewData["Message"] = result.Message;
            ViewData["TransferAmount"] = result.TransferAmount;
            ViewData["Charge"] = result.Charge;

            //logs the information of the transaction
            _logger.LogInformation(string.Format("Message: {0} {1} {2}", result.Message, result.TransferAmount, result.Charge));

            return View();
        }
    }
}
