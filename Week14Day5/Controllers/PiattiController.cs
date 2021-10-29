using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week14Day5.Core.BusinessLayer;
using Week14Day5.Helper;
using Week14Day5.Models;

namespace Week14Day5.Controllers
{
    public class PiattiController : Controller
    {
        private readonly IBusinessLayer BL;

        public PiattiController(IBusinessLayer bl)
        {
            BL = bl;
        }

        #region CRUD
        [HttpGet]
        public IActionResult Index()
        {
            var piatti = BL.GetAllPiatti();

            List<PiattoViewModel> piattiViewModel = new List<PiattoViewModel>();

            foreach (var item in piatti)
            {
                piattiViewModel.Add(item.ToPiattoViewModel());
            }

            return View(piattiViewModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(p => p.Id == id);

            var piattoViewModel = piatto.ToPiattoViewModel();

            return View(piattoViewModel);

        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(PiattoViewModel piattoViewModel)
        {
            if (ModelState.IsValid)
            {
                var piatto = piattoViewModel.ToPiatto();
                BL.AddPiatto(piatto);
                return RedirectToAction(nameof(Index));
            }
            return View(piattoViewModel);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(p => p.Id == id);
            var piattoViewModel = piatto.ToPiattoViewModel();
            return View(piattoViewModel);
        }


        [HttpPost]
        public IActionResult Update(PiattoViewModel piattoViewModel)
        {
            if (ModelState.IsValid)
            {
                var piatto = piattoViewModel.ToPiatto();
                BL.EditPiatto(piatto);
                return RedirectToAction(nameof(Index));
            }
            return View(piattoViewModel);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(p => p.Id == id);
            var piattoViewModel = piatto.ToPiattoViewModel();
            return View(piattoViewModel);
        }


        [HttpPost]
        public IActionResult Delete(PiattoViewModel piattoViewModel)
        {
            if (ModelState.IsValid)
            {
                var piatto = piattoViewModel.ToPiatto();
                BL.DeletePiatto(piatto.Id);
                return RedirectToAction(nameof(Index));
            }
            return View(piattoViewModel); ;
        }

        #endregion
    }
}

