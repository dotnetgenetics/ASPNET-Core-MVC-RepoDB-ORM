using ASPCoreMVCRepoDB.Data_Access_Layer.UnitOfWork;
using ASPCoreMVCRepoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ASPCoreMVCRepoDB.Controllers
{
   public class HomeController : Controller
   {
      private readonly ILogger<HomeController> _logger;
      private IUnitOfWork _unitOfWork;

      public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
      {
         _logger = logger;
         _unitOfWork = unitOfWork;
      }

      public IActionResult Index()
      {
         List<Athletes> model;

         model = new List<Athletes>();

         model =  _unitOfWork.AthletesRepository.GetAll().ToList();

         return View(model);
      }

      [HttpGet]
      public IActionResult Create()
      {
         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public IActionResult Create(Athletes athlete)
      {
         if (ModelState.IsValid)
         {
            _unitOfWork.AthletesRepository.Add(athlete);

            return RedirectToAction("Index");
         }

         return View("Index");
      }

      [HttpGet]
      public IActionResult Edit(int? id)
      {
         Athletes model;

         model = new Athletes();

         if (id == null)
            return NotFound();

         model = _unitOfWork.AthletesRepository.FindByID(Convert.ToInt32(id));

         if (model == null)
            return NotFound();

         return View(model);
      }

      [HttpPost]
      public ActionResult Edit(Athletes athlete)
      {
         try
         {
            _unitOfWork.AthletesRepository.Update(athlete);
            return RedirectToAction("Index");
         }
         catch
         {
            return View();
         }
      }

      [HttpGet]
      public IActionResult Delete(int? id)
      {
         Athletes model;

         model = new Athletes();

         if (id == null)
            return NotFound();

         model = _unitOfWork.AthletesRepository.FindByID(Convert.ToInt32(id));

         if (model == null)
            return NotFound();

         return View(model);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Delete(Athletes athlete)
      {
         try
         {
            _unitOfWork.AthletesRepository.Delete(athlete);
            return RedirectToAction("Index");
         }
         catch
         {
            return View();
         }
      }

      public IActionResult Privacy()
      {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}