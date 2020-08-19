namespace Models.Car.Parameters
{
    using Models.Common;

    public class Brand : ParameterBase<string>
    {
        public Brand(string value) : base(value, true, true)
        {
        }
    }
}