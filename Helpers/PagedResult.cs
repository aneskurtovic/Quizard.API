using System.Collections.Generic;

namespace Quizard.API.Helpers
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Data { get; }
        public PagedResultMetadata Metadata { get; }

        public PagedResult(IEnumerable<T> data, int total, int pageNumber, int pageSize)
        {
            Data = data;
            Metadata = new PagedResultMetadata(total, pageNumber, pageSize);
        }
    }
}
