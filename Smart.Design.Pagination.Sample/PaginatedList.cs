namespace Smart.Design.Pagination.Sample;

public class PaginatedList<T> : List<T>
{
    public int PageIndex { get; set; }

    public int TotalPages { get; set; }

    public int TotalCount { get; set; }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize) : base(items)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
    }

    public bool HasPreviousPage => PageIndex > 1;

    public bool HasNextPage => PageIndex < TotalPages;

    public static PaginatedList<T> CreateAsync(IEnumerable<T> source, int pageIndex, int pageSize)
    {
        if (source is IQueryable<T>)
        {
            throw new InvalidOperationException($"parameter {nameof(source)} can't be an IQueryable");
        }

        var count = source.Count();
        var items =  source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        return new PaginatedList<T>(items, count, pageIndex, pageSize);
    }
}