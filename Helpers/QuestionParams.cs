using System.Collections.Generic;

namespace Quizard.API.Helpers
{
    public enum CategoryOperand
    {
        Or = 1,
        And = 2
    }
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
        public IList<int> Category { get; set; } = new List<int>();
        public CategoryOperand? Operand { get; set; }
    }
}
