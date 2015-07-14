using System;
using System.Text;

namespace OnlineCookbook.Common.Filters
{
    public class IngradientFilter :GenericFilter
    {
       public IngradientFilter(int pageNumber, int pageSize)
            : base(pageNumber, pageSize)
        {
            
        }
    }
}
