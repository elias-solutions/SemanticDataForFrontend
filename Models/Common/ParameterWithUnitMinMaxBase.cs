namespace Models.Common
{
    using System;

    [Serializable]
    public abstract class ParameterWithUnitMinMaxBase<T> : ParameterWithUnitBase<T>
    {
        public ParameterWithUnitMinMaxBase(
            T value,
            T minimum,
            T maximum,
            string unit,
            bool isEditable,
            bool isVisible) : base(value, unit, isEditable, isVisible)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        public T Minimum { get; set; }

        public T Maximum { get; set; }
    }
}