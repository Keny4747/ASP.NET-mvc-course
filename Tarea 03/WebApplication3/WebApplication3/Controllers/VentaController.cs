using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.Repository;
using WebApplication3.Service;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class VentaController : Controller
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IVentaService _ventaService;

        public VentaController(IVentaRepository ventaRepository, IVentaService ventaService)
        {
            _ventaRepository = ventaRepository;
            _ventaService = ventaService;
        }
        [Authorize]
        public IActionResult Index(int pageNumber = 1, int pageSize = 3)
        {
            ViewData["categorias"] = "Hola mundo";
            var ventas = _ventaRepository.ObtenerTodos();
            var totalItems = ventas.Count();
            var totalPages = (int) Math.Ceiling(totalItems / (double)pageSize);
            var currentPageList = ventas.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var viewModel = new VentaViewModel
            {
                ventas = currentPageList,
                paginationInfo = new PaginationInfo
                {
                    currentPage = pageNumber,
                    totalItems = totalItems,
                    pageSize = pageSize,
                    totalPages = totalPages
                }
            };
            return View(viewModel);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(VentaModel venta)
        {
            if (ModelState.IsValid)
            {
                _ventaService.RealizarVenta(venta);
                return RedirectToAction("Index");
            }
            else
            {
                return View(venta);
            }
        }
        [Authorize]
        public IActionResult Actualizar(int id)
        {
            var venta = new VentaModel();
            venta = _ventaRepository.ObtenerPorID(id);
            return View(venta);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Actualizar(VentaModel venta)
        {
            if (ModelState.IsValid)
            {
                _ventaRepository.ActualizarVenta(venta);
                return RedirectToAction("Index");
            } else
            {
                return View(venta);
            }
        }
    }
}
