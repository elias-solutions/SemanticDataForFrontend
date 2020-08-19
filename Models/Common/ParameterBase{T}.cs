namespace Models.Common
{
    using System;
    using Extensions.Pack;

    [Serializable]
    public class ParameterBase<T> : ParameterBase
    {
        public ParameterBase(T value, bool isEditable, bool isVisible) : base(value, isEditable, isVisible)
        {
            Value = UndefinedValue.Cast<T>();
        }

        public T Value { get; set; }
    }
}