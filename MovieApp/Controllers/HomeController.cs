using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Data;
using MovieApp.Core.Interfaces;
using MovieApp.Interfaces;
using MovieApp.Models;
using MovieApp.Services;
using System.Diagnostics;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; 

        private IMovieViewModelService _movieService;

        public HomeController(ILogger<HomeController> logger, IRepository<Movie> movieData)
        {
            _logger = logger;
            _movieService = new MovieViewModelService(movieData);
        }

        public IActionResult Index()
        {
            var model = _movieService.GetAllMovies();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}