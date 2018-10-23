using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.Models;

namespace DotNetCore.Web.Services
{
    /// <summary>
    /// 电影存储服务
    /// </summary>
    public class MovieMemoryService : IMovieService
    {
        private readonly List<Movie> _movies = new List<Movie>();
        public MovieMemoryService()
        {
            _movies.Add(new Movie
            {
                CinemaId = 1,
                Id = 1,
                Name = "功夫",
                Starring = "周星驰",
                ReleaseDate = new DateTime(2018, 10, 1)
            });
            _movies.Add(new Movie
            {
                CinemaId = 1,
                Id = 2,
                Name = "美人鱼",
                Starring = "邓超",
                ReleaseDate = new DateTime(1997, 5, 4),
            });
            _movies.Add(new Movie
            {
                CinemaId = 2,
                Id = 3,
                Name = "赌侠",
                Starring = "刘德华",
                ReleaseDate = new DateTime(2007, 5, 4),
            });
        }

        public Task AddAsync(Movie model)
        {
            var maxId = _movies.Max(x => x.Id);
            model.Id = maxId + 1;
            _movies.Add(model);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId)
        {
            return Task.Run(() => _movies.Where(x => x.CinemaId == cinemaId));
        }
    }
}
