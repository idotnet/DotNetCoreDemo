using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.Models
{
    /// <summary>
    /// 电影表
    /// </summary>
    public class Movie
    {
        public int Id { get; set; }
        /// <summary>
        /// 电影名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 电影院Id
        /// </summary>
        public int CinemaId { get; set; }
        /// <summary>
        /// 主演
        /// </summary>
        public string Starring { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime ReleaseDate { get; set; }
    }
}
