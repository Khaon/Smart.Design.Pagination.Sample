namespace Smart.Design.Pagination.Sample;

public static class PaginationExtensions
{
    public static PaginatedList<T> Paginate<T>(this IEnumerable<T> source, int pageIndex, int pageSize)
    {
        return PaginatedList<T>.CreateAsync(source, pageIndex, pageSize);
    }
}