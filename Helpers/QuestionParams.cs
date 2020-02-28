using System.Collections.Generic;

namespace Quizard.API.Helpers
{
    public class QuestionParams
    {
        private const int MaxPageSize = 50;
        public int Offset { get; set; } = 0;
        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public string Name { get; set; }
        public IEnumerable<int> Category { get; set; }
    }
}
