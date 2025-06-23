using System.Linq.Expressions;

namespace Domain.Contracts;

public interface ISpecifications<T> where T : class 
{
    // Where   => Criteria Expression<Func<T, bool>>
    // Include => List<Expression<Func<T, object>>
    // Select  => Criteria Expression<Func<T, bool>>

    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> IncludeExpressions { get; }
    Expression<Func<T, object>> OrderBy { get; }
    Expression<Func<T, object>> OrderByDescending { get; }

    int Skip { get; }
    int Take { get; }
    bool IsPaginated { get; }   
}

