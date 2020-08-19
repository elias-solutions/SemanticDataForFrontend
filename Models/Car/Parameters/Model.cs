namespace Models.Car.Parameters
{
    using Models.Common;

    public class Model : ParameterBase<string>
    {
        public Model(string value) : base(value, true, true)
        {
        }
    }
}
