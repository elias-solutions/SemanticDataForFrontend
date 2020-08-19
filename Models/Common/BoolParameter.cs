namespace Models.Common
{
    using System;

    [Serializable]
    public class BoolParameter : ParameterBase<bool>
    {
        public BoolParameter(bool value, bool isEditable, bool isVisible) : base(value, isEditable, isVisible)
        {
        }
    }
}