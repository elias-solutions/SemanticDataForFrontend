namespace Models.Common
{
    using System;

    [Serializable]
    public class ValueWithUnitParameter<T> : ParameterBase<T>
    {
        public ValueWithUnitParameter(T value, string unit, bool isEditable, bool isVisible) : base(
            value,
            isEditable,
            isVisible)
        {
            Unit = unit;
        }

        public string Unit { get; set; }
    }
}