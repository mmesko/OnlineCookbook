
namespace OnlineCookbook.Common.Filters
{
   public class GenericFilter
    {
        

        protected int pageNumber;
        protected int pageSize;
        protected int defaultPageSize;

    
        public virtual int PageNumber
        {
            get
            {
                if (pageNumber <= 0)
                    pageNumber = 1;

                return pageNumber;
            }
        }

        
        public virtual int PageSize
        {
            get
            {
                if (pageSize <= 0 || pageSize > defaultPageSize)
                    pageSize = defaultPageSize;
                return pageSize;
            }
        }


      
        public GenericFilter(int pageNumber, int pageSize)
        {
            defaultPageSize = 20;
            this.pageSize = pageSize;
            this.pageNumber = pageNumber;
        }
    }
}
