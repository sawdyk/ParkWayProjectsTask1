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
            try
            {
                return View();
            }
            catch
            {
                return View("Error1");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CalculateTransactionFee(long amount)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Error1");
                }

                var result = await _transactionsRepo.calculateTransactionFeeAsync(amount);

                ViewData["Message"] = result.Message;
                ViewData["TransferAmount"] = result.TransferAmount;
                ViewData["Charge"] = result.Charge;


                return View();
            }
            catch
            {
                return View("Error1");
            }
            
        }
    }
}
