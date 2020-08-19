namespace Models.Common
{
    using System;

    [Serializable]
    public class ParameterWithUnitBase : ParameterBase
    {
        public ParameterWithUnitBase(object value, string unit, bool isEditable, bool isVisible) : base(
            value,
            isEditable,
            isVisible)
        {
            Unit = unit;
        }

        public string Unit { get; set; }
    }
}