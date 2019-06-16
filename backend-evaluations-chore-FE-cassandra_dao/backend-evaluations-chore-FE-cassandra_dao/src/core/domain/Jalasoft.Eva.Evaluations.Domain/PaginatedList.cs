namespace Jalasoft.Eva.Evaluations.Domain
{
    using System.Collections.Generic;

    public class PaginatedList<T>
    {
        public PaginatedList(IList<T> list, int totalLenght)
        {
            this.TotalLenght = totalLenght;
            this.Data = list;
            this.PageLength = list.Count;
        }

        public int TotalLenght { get; private set; }

        public int PageLength { get; private set; }

        public IList<T> Data { get; private set; }
    }
}
