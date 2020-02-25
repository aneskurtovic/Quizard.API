namespace Quizard.API.Helpers
{
    public class PagedResultMetadata
    {
        public int Total { get; }
        public int Offset { get; }
        public int PageSize { get; }
        public string Name { get; set; }

        public PagedResultMetadata(int total, int offset, int pageSize, string name)
        {
            Total = total;
            Offset = offset;
            PageSize = pageSize;
            Name = name;
        }
    }
}