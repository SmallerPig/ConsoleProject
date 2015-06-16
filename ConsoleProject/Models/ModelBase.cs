using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsoleProject.Models
{
    public abstract class ModelBase
    {

        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    }
}