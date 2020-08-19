namespace Api.Entities
{
    using Api.DataAccess;
    using Api.Entities.Common;

    [Entity]
    internal class Car : EntityBase
    {
        public double Speed { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }
    }
}