
namespace OnlineCookbook.Common.Filters
{
   public interface IFilter
    {
        string SortOrder { get; }
        int PageNumber { get; }
        int PageSize { get; }
    }
}
