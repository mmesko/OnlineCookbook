using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCookbook.Common.Filters
{
   public class CommentFilter : GenericFilter
    {
       public CommentFilter(int pageNumber, int pageSize)
           : base(pageNumber,pageSize)
       {
       
       }


    }
}
