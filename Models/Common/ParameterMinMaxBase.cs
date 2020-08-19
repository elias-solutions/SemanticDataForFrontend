namespace Models.Common
{
    using System;

    [Serializable]
    public class ParameterMinMaxBase<T> : ParameterBase<T>
    {
        public ParameterMinMaxBase(T value, T minimum, T maximum, bool isEditable, bool isVisible) : base(
            value,
            isEditable,
            isVisible)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        public T Minimum { get; set; }

        public T Maximum { get; set; }
    }
}