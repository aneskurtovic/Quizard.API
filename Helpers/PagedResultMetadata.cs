namespace Quizard.API.Helpers
{
    public class PagedResultMetadata
    {
        public int Total { get; }
        public int Offset { get; }
        public int PageSize { get; }
        
        public PagedResultMetadata(int total, int offset, int pageSize)
        {
            Total = total;
            Offset = offset;
            PageSize = pageSize;
        }
    }
}