namespace Models.Car
{
    using System;
    using System.Collections.Generic;
    using Models.Common;

    [Serializable]
    public class CarModel: FrontendModel
    {
        public Guid Key { get; }

        public IEnumerable<ParameterBase> Parameters { get; }

        public CarModel(Guid key, IEnumerable<ParameterBase> parameters)
        {
            Key = key;
            Parameters = parameters;
        }
    }
}