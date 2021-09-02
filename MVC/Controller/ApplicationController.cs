using DigicelApps.Models;
using DigicelApps.Models.DTOs;
using DigicelApps.Services;
using DigicelApps.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigicelApps.Controllers
{

    public class ApplicationController : Controller
    {

        private IApplication _app;

        private ICategory _category;

        public ApplicationController(IApplication app, ICategory category)
        {
            _app = app;
            _category = category;
        }


        [HttpGet]
        public async Task<IActionResult>  CreateApp()
        {
            ViewBag.categories =await _category.Categories();
            return View("Index");
        }


        [HttpGet]
        public  IActionResult Menu()
        {
           
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ViewApps()
        {
           var apps = await _app.getAll();
            return View(apps);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.categories = await _category.Categories();
            var app = await _app.GetById(id);
            return View(app);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Application app)
        {
            if (ModelState.IsValid)
            {
                if (await _app.Update(app))
                {
                    ViewBag.success = "La aplicación fue Editada Exitosamente";
                    return View("ViewApps",await _app.getAll());
                }
                else
                {
                    ViewBag.error = "La applicación no pudo ser editada intente nuevamente";
                    return View("ViewApps",await _app.getAll());
                }
            }
            else
            {
                ViewBag.categories = await _category.Categories();
                return View("Edit", app);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.categories = await _category.Categories();
            var app = await _app.GetById(id);
            return View(app);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Application app)
        {
                if (await _app.Delete(app.Id))
                {
                    ViewBag.success = "La aplicación fue Eliminada Exitosamente";
                    return View("ViewApps", await _app.getAll());
                }
                else
                {
                    ViewBag.error = "La applicación no puedo ser eliminada nuevamente";
                    return View("ViewApps", await _app.getAll());
                }
            }
          
        



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateApp(ApplicationCreationDto app)
        {
            if (ModelState.IsValid)
            {
                if (await _app.Create(app))
                {
                    ViewBag.success = "La aplicación fue creada Exitosamente";
                    return View("ViewApps",await _app.getAll());
                }
                else
                {
                    ViewBag.error = "La applicación no puedo ser creada intente nuevamente";
                    return  View("Index",app);
                }              
            }
            else
            {
                ViewBag.categories = await _category.Categories();
                return View("Index", app);
            }                        
        }



    }
}
