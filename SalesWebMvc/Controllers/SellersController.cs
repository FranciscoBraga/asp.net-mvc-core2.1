using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Service;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using System.Diagnostics;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartamentService _departamentService;

        public SellersController(SellerService sellerService, DepartamentService departamentService)
        {
            _sellerService = sellerService;
            _departamentService = departamentService;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _sellerService.FindAllAsync();
            return View(lista);
        }

        public async Task<IActionResult> Create()
        {
            var departaments = await _departamentService.FindAllAsync();
            var viewModel = new SellerFormViewModelcs { Departaments = departaments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SellerFormViewModelcs sellers)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departamentService.FindAllAsync();
                var viewModel = new SellerFormViewModelcs { Departaments = departaments };
                return View(viewModel);
            }        
           await _sellerService.InsertAsync(sellers.Seller);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "In not provided" });
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new {message = "In not found" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sellerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "In not provided" });
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "In not found" });
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "In not provided" });
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "In not found" });
            }

            var departament =  await _departamentService.FindAllAsync();
            var viewModel = new SellerFormViewModelcs { Seller = obj, Departaments = departament };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Edit(int id,SellerFormViewModelcs sellerForm)
        {
            if (!ModelState.IsValid)
            {
                var departaments = await _departamentService.FindAllAsync();
                var viewModel = new SellerFormViewModelcs { Departaments = departaments };
                return View(viewModel);
            }
            if (id != sellerForm.Seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "In mismatach" });
            }
            try
            {
                 await _sellerService.UpdateAsync(sellerForm.Seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
                     
            }
          
           
        }


        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }

    }
}