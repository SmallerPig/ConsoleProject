namespace ConsoleProject.Areas.Admin.Models
{
    /// <summary>
    /// 自定义分页类,主要用来传递三个重要的分页参数:
    /// </summary>
    public class SmpPager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="actionName">action的名称</param>
        /// <param name="count">总计的条目数量</param>
        /// <param name="pageIndex">当前页码</param>
        public SmpPager(string actionName, int count, int pageIndex)
        {
            this.ActionName = actionName;
            this.Count = count;
            this.PageIndex = pageIndex;
        }

        public int PageIndex { get; set; }

        public string ActionName { get; set; }

        public int Count { get; set; }

    }
}