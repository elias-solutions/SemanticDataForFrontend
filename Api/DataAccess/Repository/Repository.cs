namespace Api.DataAccess.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Api.DataAccess.Wrapper;
    using Argument.Check;

    public class Repository<T>
    {
        private readonly IDataProviderWrapper<T> _dataProviderWrapper;

        public Repository(IDataProviderWrapper<T> dataProviderWrapper)
        {
            Throw.IfNull(() => dataProviderWrapper);

            _dataProviderWrapper = dataProviderWrapper;
        }

        public event Action<IEnumerable<T>> AddedEvent;
        public event Action<IEnumerable<T>> UpdatedEvent;
        public event Action<IEnumerable<T>> DeletedEvent;

        public Task<IEnumerable<T>> GetAsync(params Guid[] keys)
        {
            return _dataProviderWrapper.GetAsync(keys);
        }

        public async Task AddAsync(params T[] items)
        {
            Throw.IfNullOrEmpty(() => items);

            await _dataProviderWrapper.AddAsync(items);
            AddedEvent?.Invoke(items);
        }

        public async Task UpdateAsync(params T[] items)
        {
            Throw.IfNullOrEmpty(() => items);

            await _dataProviderWrapper.UpdateAsync(items);
            UpdatedEvent?.Invoke(items);
        }

        public async Task DeleteAsync(params T[] items)
        {
            Throw.IfNullOrEmpty(() => items);

            await _dataProviderWrapper.DeleteAsync(items);
            DeletedEvent?.Invoke(items);
        }
    }
}