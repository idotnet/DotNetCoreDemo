using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.Models;
using DotNetCore.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICinemaService _cinemaService;
        public MovieController(
            IMovieService movieService, 
            ICinemaService cinemaService)
        {
            _movieService = movieService;
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index(int cinemaId)
        {
            var cinema = await _cinemaService.GetByIdAsync(cinemaId);

            ViewBag.Title = $"{cinema.Name}这个电影院上映的电影有：";
            ViewBag.CinemaId = cinemaId;

            var movies = await _movieService.GetByCinemaAsync(cinemaId);

            return View(movies);
        }

        public ActionResult Add(int cinemaId)
        {
            ViewBag.Title = "添加电影";
            return View(new Movie{ CinemaId = cinemaId });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.AddAsync(movie);
            }
            return RedirectToAction("Index", new { cinemaId = movie.CinemaId });
        }
    }
}