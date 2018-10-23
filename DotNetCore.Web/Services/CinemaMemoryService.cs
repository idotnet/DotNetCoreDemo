using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.Models;

namespace DotNetCore.Web.Services
{
    /// <summary>
    /// 电影院存储服务
    /// </summary>
    public class CinemaMemoryService : ICinemaService
    {
        private readonly List<Cinema> _cinemas = new List<Cinema>();
        public CinemaMemoryService()
        {
            _cinemas.Add(new Cinema
            {
                Id = 1,
                Name = "万达影城",
                Location = "罗湖区河边路一号",
                Capacity = 2000
            });
            _cinemas.Add(new Cinema {
                Id = 2,
                Name ="巨星影城",
                Location = "华强路3901号",
                Capacity = 1000
            });
        }

        public Task<IEnumerable<Cinema>> GetllAllAsync()
        {
            return Task.Run(() => _cinemas.AsEnumerable());
        }

        public Task<Cinema> GetByIdAsync(int id)
        {
            return Task.Run(() => _cinemas.FirstOrDefault(x => x.Id == id));
        }

        public Task AddAsync(Cinema model)
        {
            var maxId = _cinemas.Max(x => x.Id);
            model.Id = maxId + 1;
            _cinemas.Add(model);
            return Task.CompletedTask;

        }
    }
}
