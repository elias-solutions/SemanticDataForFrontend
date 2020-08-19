namespace Models.Common
{
    using System;
    using Newtonsoft.Json;

    [Serializable]
    public class ParameterBase
    {
        [JsonConstructor]
        public ParameterBase(object undefinedValue, bool isEditable, bool isVisible)
        {
            UndefinedValue = undefinedValue;
            IsEditable = isEditable;
            IsVisible = isVisible;
        }

        [JsonIgnore] public object UndefinedValue { get; set; }

        public bool IsEditable { get; set; }

        public bool IsVisible { get; set; }
    }
}