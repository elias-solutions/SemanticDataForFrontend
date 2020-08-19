namespace Api.DataAccess.Wrapper
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDataProviderWrapper<T>
    {
        Task<IEnumerable<T>> GetAsync(params Guid[] keys);
        Task AddAsync(IEnumerable<T> items);
        Task UpdateAsync(IEnumerable<T> items);
        Task DeleteAsync(IEnumerable<T> items);
    }
}