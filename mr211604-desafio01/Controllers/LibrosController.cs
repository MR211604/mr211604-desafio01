using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Biblioteca.BL.Interfaces;
using Biblioteca.Entities.Dtos;

namespace mr211604_desafio01.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ILibroService _libroService;
        private readonly IAutorService _autorService;
        private readonly ICategoriaService _categoriaService;

        public LibrosController(ILibroService libroService, IAutorService autorService, ICategoriaService categoriaService)
        {
            _libroService = libroService;
            _autorService = autorService;
            _categoriaService = categoriaService;
        }

        // GET: Libros
        public async Task<IActionResult> Index()
        {
            return View(await _libroService.GetAllLibrosAsync());
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _libroService.GetLibroByIdAsync(id.Value);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libros/Create
        public async Task<IActionResult> Create()
        {
            ViewData["AutorId"] = new SelectList(await _autorService.GetAllAutoresAsync(), "Codigo", "Apellido");
            ViewData["CategoriaId"] = new SelectList(await _categoriaService.GetAllCategoriasAsync(), "Codigo", "Nombre");
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LibroDto libroDto)
        {
            if (ModelState.IsValid)
            {
                await _libroService.InsertLibroAsync(libroDto);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(await _autorService.GetAllAutoresAsync(), "Codigo", "Apellido", libroDto.AutorId);
            ViewData["CategoriaId"] = new SelectList(await _categoriaService.GetAllCategoriasAsync(), "Codigo", "Nombre", libroDto.CategoriaId);
            return View(libroDto);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _libroService.GetLibroByIdAsync(id.Value);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(await _autorService.GetAllAutoresAsync(), "Codigo", "Apellido", libro.AutorId);
            ViewData["CategoriaId"] = new SelectList(await _categoriaService.GetAllCategoriasAsync(), "Codigo", "Nombre", libro.CategoriaId);
            return View(libro);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LibroDto libroDto)
        {
            if (id != libroDto.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _libroService.UpdateLibroAsync(libroDto);
                if (result == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(await _autorService.GetAllAutoresAsync(), "Codigo", "Apellido", libroDto.AutorId);
            ViewData["CategoriaId"] = new SelectList(await _categoriaService.GetAllCategoriasAsync(), "Codigo", "Nombre", libroDto.CategoriaId);
            return View(libroDto);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _libroService.GetLibroByIdAsync(id.Value);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _libroService.DeleteLibroAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
