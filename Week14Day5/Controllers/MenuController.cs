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
    public class MenuController : Controller
    {
        private readonly IBusinessLayer BL;

        public MenuController(IBusinessLayer bl)
        {
            BL = bl;
        }

        #region CRUD
        [HttpGet]
        public IActionResult Index()
        {
            var menu = BL.GetAllMenus();

            List<MenuViewModel> menuViewModel = new List<MenuViewModel>();

            foreach (var item in menu)
            {
                menuViewModel.Add(item.ToMenuViewModel());
            }

            return View(menuViewModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var menu = BL.GetAllMenus().FirstOrDefault(m => m.Id == id);

            var menuViewModel = menu.ToMenuViewModel();

            return View(menuViewModel);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                var menu = menuViewModel.ToMenu();
                BL.AddMenu(menu);
                return RedirectToAction(nameof(Index));
            }
            return View(menuViewModel);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var menu = BL.GetAllMenus().FirstOrDefault(m => m.Id == id);
            var menuViewModel = menu.ToMenuViewModel();
            return View(menuViewModel);
        }


        [HttpPost]
        public IActionResult Update(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                var menu = menuViewModel.ToMenu();
                BL.EditMenu(menu);
                return RedirectToAction(nameof(Index));
            }
            return View(menuViewModel);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var menu = BL.GetAllMenus().FirstOrDefault(m => m.Id == id);
            var menuViewModel = menu.ToMenuViewModel();
            return View(menuViewModel);
        }


        [HttpPost]
        public IActionResult Delete(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                var menu = menuViewModel.ToMenu();
                BL.DeleteMenu(menu.Id);
                return RedirectToAction(nameof(Index));

            }
            return View(menuViewModel);
        }

        #endregion
    }

}
