using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.Repository;
using WebApplication3.Service;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IRolRepository rolRepository;
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioRepository usuarioRepository, IRolRepository rolRepository, IUsuarioService usuarioService)
        {
            this.usuarioRepository = usuarioRepository;
            this.rolRepository = rolRepository;
            this.usuarioService = usuarioService;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
              return View(usuarioRepository.ObtenerTodos());
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var usuarioModel = usuarioRepository.ObtenerPorID(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            var roles = rolRepository.ObtenerTodos();
            ViewBag.Roles = roles;
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                usuarioModel.contrasenia = Utilitarios.GetMd5Hash(usuarioModel.contrasenia);
                var roles = usuarioModel.roles.Select(roleId => new RolModel { id = roleId }).ToList();
                usuarioService.RegistrarUsuario(usuarioModel, roles);
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioModel);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var usuarioModel = usuarioRepository.ObtenerPorID(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            return View(usuarioModel);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,usuario,contrasenia")] UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuarioModel.contrasenia = Utilitarios.GetMd5Hash(usuarioModel.contrasenia);
                    usuarioRepository.Actualizar(usuarioModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioModelExists(usuarioModel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioModel);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var usuarioModel = usuarioRepository.ObtenerPorID(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioModel = usuarioRepository.ObtenerPorID(id);
            if (usuarioModel != null)
            {
                usuarioRepository.Eliminar(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioModelExists(int id)
        {
          return usuarioRepository.ObtenerPorID(id) != null;
        }
    }
}
