using Microsoft.AspNetCore.Mvc;
using Project_UOW_BusinessLayer.Abstract;
using Project_UOW_EntityLayer.Concrete;
using Project_UOW_PresentationLayer.Models;
using System.Collections.Generic;
using System;

namespace Project_UOW_PresentationLayer.Controllers
{
    //Controller tarafında UOW çağırmama  gerek kalmadı çünkü businessta çağırmıştık.
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IProcessDetailService _processDetailService;

        public AccountController(IAccountService accountService, IProcessDetailService processDetailService)
        {
            _accountService = accountService;
            _processDetailService = processDetailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel p)
        {
            var value1 = _accountService.TGetByID(p.SenderID); //göndeici
            var value2 = _accountService.TGetByID(p.ReceiverID); //alıcı

            if (value1.AccountBalance > p.Amount) 
            {
                value1.AccountBalance -= p.Amount;//girilen miktar kadar düşer
                value2.AccountBalance += p.Amount;//girilen miktar buna eklenir. Yani birinin gönderdiği para ondan eksilir diğerine o para geçer.

              //multipupdate: aynı anda birden çok işlem 

                List<Account> modifiedAccounts = new List<Account>()  //value1 ve 2yi modifiedaccount sayesinde bir liste formatında tutucaz.
                 {
                value1,
                value2
                 };

                ProcessDetail detail = new ProcessDetail();
                detail.SenderName = value1.AccountName;
                detail.ReceiverName = value2.AccountName;
                detail.ProcessDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                detail.Amount = p.Amount;
                _processDetailService.TInsert(detail);

                _accountService.TMultiUpdate(modifiedAccounts);//aynı anda iki tarafın da hem parayı gönderen hem alan değerlerini güncellemeyi sağlar.
            }

            else //şifreler uyuşmuyorsa
            {
                ModelState.AddModelError("", "Bakiyeniz işlem yapmak istediğiniz işlem tutarı için yeterli değil !");
            }
            return View();
        }

    }
}
