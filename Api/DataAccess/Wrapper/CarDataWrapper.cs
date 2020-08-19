namespace Api.DataAccess.Wrapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Api.Converter;
    using Api.Entities;
    using Models.Car;

    internal class CarDataWrapper : IDataProviderWrapper<CarModel>
    {
        private readonly CarConverter _converter;
        private readonly EntityDbContext _dbContext;

        public CarDataWrapper(EntityDbContext dbContext, CarConverter converter)
        {
            _dbContext = dbContext;
            _converter = converter;
        }

        public Task<IEnumerable<CarModel>> GetAsync(params Guid[] identifiers)
        {
            var set = _dbContext.Set<Car>();

            if (identifiers.Any())
            {
                var entities = set.Where(item => identifiers.Any(identifier => item.Identifier.Equals(identifier))).ToList();
                var models = _converter.Convert(entities);
                return Task.FromResult(models);
            }

            return Task.FromResult(_converter.Convert(set.ToList()));
        }

        public async Task AddAsync(IEnumerable<CarModel> items)
        {
            var cars = _converter.Convert(items).ToList();
            await _dbContext.Set<Car>().AddRangeAsync(cars);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(IEnumerable<CarModel> items)
        {
            await DeleteAsync(items);
            await AddAsync(items);
        }

        public async Task DeleteAsync(IEnumerable<CarModel> items)
        {
            var set = _dbContext.Set<Car>().ToList();
            var originals = set.Where(item => items.Any(car => car.Key.Equals(item.Identifier))).ToList();
            _dbContext.RemoveRange(originals);
            await _dbContext.SaveChangesAsync();
        }
    }
}