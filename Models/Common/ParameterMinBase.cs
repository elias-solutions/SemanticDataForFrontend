namespace Models.Common
{
    using System;

    [Serializable]
    public class ParameterMinBase<T> : ParameterBase<T>
    {
        public ParameterMinBase(T value, T minimum, bool isEditable, bool isVisible) : base(
            value,
            isEditable,
            isVisible)
        {
            Minimum = minimum;
        }

        public T Minimum { get; set; }
    }
}