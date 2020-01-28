namespace Quizard.API.Helpers
{
    public class PagedResultMetadata
    {
        public int Total { get; }
        public int PageNumber { get; }
        public int PageSize { get; }

        public PagedResultMetadata(int total, int pageNumber, int pageSize)
        {
            Total = total;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}