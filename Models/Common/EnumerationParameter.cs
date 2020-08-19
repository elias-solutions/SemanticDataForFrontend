namespace Models.Common
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public abstract class EnumerationParameter<T> : ParameterBase<T>
    {
        public EnumerationParameter(T value, IEnumerable<T> values, bool isEditable, bool isVisible) : base(
            value,
            isEditable,
            isVisible)
        {
            Values = values;
        }

        public IEnumerable<T> Values { get; set; }
    }
}