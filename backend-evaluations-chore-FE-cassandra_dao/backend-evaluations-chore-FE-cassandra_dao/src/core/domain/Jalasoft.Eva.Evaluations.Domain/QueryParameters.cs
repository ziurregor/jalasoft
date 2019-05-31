namespace Jalasoft.Eva.Evaluations.Domain
{
    using System;

    public class QueryParameters
    {
        public SearchCriteria SearchCriteria { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public SortCriteria SortCriteria { get; set; }
    }
}