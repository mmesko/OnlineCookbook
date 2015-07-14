using System;
using System.Text;

namespace OnlineCookbook.Common.Filters
{
    public class IngradientFilter : IFilter
    {

        public string SortOrder { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }

        private readonly int DefaultPageSize = 50;
        private readonly string DefaultSortOrder = "Abrv";


        public IngradientFilter(string sortOrder, int pageNumber, int pageSize)
        {
            try
            {
                SortOrder = SetSortOrder(sortOrder);
                SetPageNumberAndSize(pageNumber, pageSize);
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }

        public IngradientFilter(string sortOrder, string sortDirection, int pageNumber, int pageSize)
        {
            try
            {
                SortOrder = SetSortOrder(sortOrder) + SetSortDirection(sortDirection);
                SetPageNumberAndSize(pageNumber, pageSize);
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }

        private void SetPageNumberAndSize(int pageNumber = 1, int pageSize = 0)
        {
            PageNumber = (pageNumber > 0) ? pageNumber : 1;
            PageSize = (pageSize > 0 && pageSize <= DefaultPageSize) ? pageSize : DefaultPageSize;
        }

        private string SetSortOrder(string sortOrder)
        {
            switch (sortOrder)
            {
                case "Abrv":
                case "IngradientName":
                    return sortOrder;
                case "":
                    return DefaultSortOrder;
                default:
                    throw new ArgumentException("Invalid SortOrder.");
            }
        }

        private string SetSortDirection(string sortDirection)
        {
            if (sortDirection.ToLower() == "asc" || sortDirection == "")
            {
                return "";
            }
            else if (sortDirection.ToLower() == "desc")
            {
                return " descending";
            }
            else
            {
                throw new ArgumentException("Invalid SortDirection.");
            }
        }

    }
}
