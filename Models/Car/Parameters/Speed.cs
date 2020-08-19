namespace Models.Car.Parameters
{
    using Models.Common;

    public class Speed : ParameterMinBase<double>
    {
        public Speed(double value) : base(value, 0,true, true)
        {
        }
    }
}
