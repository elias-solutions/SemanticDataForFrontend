namespace Api.Converter
{
    using System.Collections.Generic;
    using System.Linq;
    using Api.Entities;
    using Models.Car;
    using Models.Car.Parameters;
    using Models.Common;

    internal class CarConverter
    {
        public IEnumerable<CarModel> Convert(IEnumerable<Car> entities)
        {
            foreach (var entity in entities)
            {
                yield return new CarModel(entity.Key, GetParameters(entity).ToList());
            }
        }

        public IEnumerable<Car> Convert(IEnumerable<CarModel> models)
        {
            var entites = models.Select(Convert);
            return entites;
        }

        private Car Convert(CarModel model)
        {
            return new Car
            {
                Key = model.Key,
                Brand = model.Parameters.OfType<Brand>().First().Value,
                Model = model.Parameters.OfType<Model>().First().Value,
                Speed = model.Parameters.OfType<Speed>().First().Value,
            };
        }

        private IEnumerable<ParameterBase> GetParameters(Car entity)
        {
            yield return new Speed(entity.Speed);
            yield return new Brand(entity.Model);
            yield return new Model(entity.Brand);
        }
    }
}