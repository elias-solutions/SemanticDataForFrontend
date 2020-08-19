namespace Models.Common
{
    using System;

    [Serializable]
    public abstract class ParameterWithUnitMinBase<T> : ParameterWithUnitBase<T>
    {
        public ParameterWithUnitMinBase(T value, T minimum, string unit, bool isEditable, bool isVisible) : base(
            value,
            unit,
            isEditable,
            isVisible)
        {
            Minimum = minimum;
        }

        public T Minimum { get; set; }
    }
}