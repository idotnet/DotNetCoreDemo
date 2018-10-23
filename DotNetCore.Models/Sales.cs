using System;

namespace DotNetCore.Models
{
    /// <summary>
    /// 销量表
    /// </summary>
    public class Sales
    {
        /// <summary>
        /// 电影院Id
        /// </summary>
        public int CinemaId { get; set; }
        /// <summary>
        /// 电影Id
        /// </summary>
        public int MovieId { get; set; }
        /// <summary>
        /// 观众人数
        /// </summary>
        public int AudienceCount { get; set; }
    }
}
