namespace Models.Common
{
    using System;
    using Extensions.Pack;

    [Serializable]
    public abstract class ParameterWithUnitBase<T> : ParameterWithUnitBase
    {
        public ParameterWithUnitBase(T value, string unit, bool isEditable, bool isVisible) : base(
            value,
            unit,
            isEditable,
            isVisible)
        {
        }

        public T Value => UndefinedValue.Cast<T>();
    }
}