using System.Collections.Generic;

namespace Domain.Shared
{
    public class PageModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
    }
}
