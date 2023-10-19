using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Data;
using MovieApp.Core.Interfaces;
using MovieApp.Interfaces;
using MovieApp.Models;
using MovieApp.Services;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {

        private readonly IMovieViewModelService _movieService;

        public MoviesController(IMovieViewModelService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var model = _movieService.GetAllMovies();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _movieService.GetMovieById(id);
            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.AddMovie(movie);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _movieService.GetMovieById(id);
            if (model == null) {
                return View("Sorry something went wrong. Try again.");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MovieViewModel movie)
        {
            if (ModelState.IsValid) {
                _movieService.UpdateMovie(movie);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _movieService.DeleteMovie(id);
            return RedirectToAction("Index");
        }

    }
}
