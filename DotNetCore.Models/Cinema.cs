using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore.Models
{
    /// <summary>
    /// 电影院表
    /// </summary>
    public class Cinema
    {
        public int Id { get; set; }
        /// <summary>
        /// 电影院名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 场所（地址）
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 座位数
        /// </summary>
        public int Capacity { get; set; }
    }
}
