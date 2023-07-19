namespace Housing.Application.Common.Models;

public interface IQueryBuilder<T>
{
    IQueryable<T> BuildSortingQuery(IQueryable<T> source, string attribute, bool ascending);
}